using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadPreferenceStatus : MonoBehaviour
{
    //Placeholder for preference (will show as empty if there is no data to fill this section).
    public TMP_Text preference001;

    //Placeholder for preference (will show as empty if there is no data to fill this section).
    public TMP_Text preference002;

    //Placeholder for preference (will show as empty if there is no data to fill this section).
    public TMP_Text preference003;

    //Placeholder for preference (will show as empty if there is no data to fill this section).
    public TMP_Text preference004;

    //Placeholder for preference (will show as empty if there is no data to fill this section).
    public TMP_Text preference005;

    //A list of string-subtrait pair lists (which represent pages), which will be used to extract information about page.
    public List<List<Preference>> preferencePages;

    //A list of the text object placeholders for the text to go into.
    public List<TMP_Text> textObjects;

    //Represents the number of the page the pet is on.
    private int index;

    /** Collects all of the preference objects from the pet and organizes them into sorted lists.
     Ones those lists are sorted, they will then be displayed depending on the current index.
    */
    void Start()
    {
        uploadData();
        displayOnPreference();
    }

    /** Uploads data from the pet to the load trait status script.
     Parses the data into pages, which should be flipped through accordingly.
    */

    private void uploadData()
    {
        textObjects = new List<TMP_Text>();
        textObjects.Add(preference001);
        textObjects.Add(preference002);
        textObjects.Add(preference003);
        textObjects.Add(preference004);
        textObjects.Add(preference005);
        index = 0;
        preferencePages = new List<List<Preference>>();
        List<Preference> petPrefList = GameObject.FindGameObjectWithTag("Pet").GetComponent<PetBehaviour>().getPreferenceManager().getPreferenceList();
        List<Preference> newPrefList = new List<Preference>();
        for (int i = 0; i < petPrefList.Count; i++)
        {
            newPrefList.Add(petPrefList[i]);
            if (i + 1 % 5 == 0)
            {
                preferencePages.Add(newPrefList);
                newPrefList = new List<Preference>();
            }
        }
        if (newPrefList.Count > 0)
        {
            preferencePages.Add(newPrefList);
        }
    }

    /** Displays the page on the status screen. */

    private void displayOnPreference()
    {

        for (int i = 0; i < textObjects.Count; i++)
        {
            textObjects[i].text = "";
        }

        for (int i = 0; i < preferencePages[index].Count; i++)
        {
            string mainText = "" + preferencePages[index][i].getType() + " Preference: ";
            if (preferencePages[index][i].getInteraction() != null)
            {
                if (preferencePages[index][i].getInteraction().getID() != -1)
                {
                    mainText += "" + preferencePages[index][i].getInteraction().getName();
                }
                else {
                    mainText += " N/A";
                }
            }
            else {
                mainText += " N/A";
            }
            textObjects[i].text = mainText;
        }

    }

    /** Flips the page to the next one (forward).*/

    public void incrementIndex()
    {
        index++;
        if (index >= preferencePages.Count)
        {
            index = 0;
        }
        displayOnPreference();
    }

    /** Flips the page to the previous one (backward).*/

    public void decrementIndex()
    {
        index--;
        if (index < 0)
        {
            index = preferencePages.Count - 1;
        }
        displayOnPreference();
    }
}
