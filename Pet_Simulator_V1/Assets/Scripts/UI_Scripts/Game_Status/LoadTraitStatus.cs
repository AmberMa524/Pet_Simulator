using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadTraitStatus : MonoBehaviour
{

    /**Loads traits and subtraits from the pet and displays them in the trait status
     * screen. If a trait has multiple subtraits (more than 5), their subtraits will be
     spread across mutliple pages.*/

    //Represents the title trait for the page head.
    public TMP_Text mainTrait;

    //Placeholder for subtrait (will show as empty if there is no data to fill this section).
    public TMP_Text subTrait001;

    //Placeholder for subtrait (will show as empty if there is no data to fill this section).
    public TMP_Text subTrait002;

    //Placeholder for subtrait (will show as empty if there is no data to fill this section).
    public TMP_Text subTrait003;

    //Placeholder for subtrait (will show as empty if there is no data to fill this section).
    public TMP_Text subTrait004;

    //Placeholder for subtrait (will show as empty if there is no data to fill this section).
    public TMP_Text subTrait005;

    //A list of string-subtrait pair lists (which represent pages), which will be used to extract information about page.
    public List<List<StringValuePair>> listOfStringValues;

    //A list of the text object placeholders for the text to go into.
    public List<TMP_Text> textObjects;

    //Represents the number of the page the pet is on.
    private int index;

    /** Collects all of the trait objects from the pet and organizes them into sorted lists.
     Ones those lists are sorted, they will then be displayed depending on the current index.
    */
    void Start()
    {
        uploadData();
        displayOnTrait();
    }

    /** Uploads data from the pet to the load trait status script.
     Parses the data into pages, which should be flipped through accordingly.
    */

    private void uploadData() {
        textObjects = new List<TMP_Text>();
        textObjects.Add(subTrait001);
        textObjects.Add(subTrait002);
        textObjects.Add(subTrait003);
        textObjects.Add(subTrait004);
        textObjects.Add(subTrait005);
        index = 0;
        listOfStringValues = new List<List<StringValuePair>>();
        List<Trait> petTraitList = GameObject.FindGameObjectWithTag("Pet").GetComponent<PetPersonality>().getTraitList();
        for (int i = 0; i < petTraitList.Count; i++)
        {
            List<StringValuePair> newPairList = new List<StringValuePair>();
            for (int j = 0; j < petTraitList[i].getSubTraitList().Count; j++)
            {
                newPairList.Add(new StringValuePair(petTraitList[i].getType(), petTraitList[i].getSubTraitList()[j]));
                if (j + 1 % 5 == 0)
                {
                    listOfStringValues.Add(newPairList);
                    newPairList = new List<StringValuePair>();
                }
            }
            if (newPairList.Count > 0)
            {
                listOfStringValues.Add(newPairList);
            }
        }
    }

    /** Displays the page on the status screen. */

    private void displayOnTrait() {

        string title = listOfStringValues[index][0].getKey();
        mainTrait.text = title;
        for (int i = 0; i < textObjects.Count; i++) {
            textObjects[i].text = "";
        }

        for (int i = 0; i < listOfStringValues[index].Count; i++) { 
            textObjects[i].text = "" + listOfStringValues[index][i].getValue().getName()
                + ": " + listOfStringValues[index][i].getValue().getValue();
        }

    }

    /** Flips the page to the next one (forward).*/

    public void incrementIndex() {
        index++;
        if (index >= listOfStringValues.Count)
        {
            index = 0;
        }
        displayOnTrait();
    }

    /** Flips the page to the previous one (backward).*/

    public void decrementIndex() {
        index--;
        if (index < 0) {
            index = listOfStringValues.Count - 1;
        }
        displayOnTrait();
    }
}
