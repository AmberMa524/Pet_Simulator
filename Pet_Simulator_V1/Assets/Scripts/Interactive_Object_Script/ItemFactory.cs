using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemFactory : MonoBehaviour
{
    /** Designed to create a specified number of game objects of type interactiveObject.
     The factory contains its own canvas, which displays a catalogue of different items that can
     be created.
    */

    //Represents the spawn point of the objects upon creation.
    public GameObject spawnPoint;

    //Represents the list of objects that can be dispensed from this factory.
    public List<GameObject> objectList;

    //Represents the current page of the factory catalogue.
    private int currentPage;

    //Represents the canvas that the catalogue would be placed on.
    public GameObject mainCanvas;

    //Represents the name of the object selected.
    public TMP_Text nameVal;

    //Represents the type of the object selected.
    public TMP_Text type;

    //Represents the subtype of the object selected.
    public TMP_Text subtype;

    //Represents the image attribute of the object selected.
    public Image imageVal;

    //For items that contain a time constrainer, the bounds may be displayed as a warning to
    //the player in case they want to use it.
    public TMP_Text bounds;

    //Represents whether or not the factory has been clicked.
    private bool clicked;

    /** 
     Factory should reset at the very start.
     */
    void Start()
    {
        resetFactory();
    }

    /** If the page of the factory changes, the page should reflect this.
     */

    void Update()
    {
        updatePage();
    }

    /** Switches to the previous page of the catalogue.*/

    public void prevPage()
    {
        if (objectList != null)
        {
            currentPage--;
            if (currentPage < 0)
            {
                currentPage = objectList.Count - 1;
            }
        }
    }

    /** Switches to the next page of the catalogue.*/

    public void nextPage()
    {
        if (objectList != null)
        {
            currentPage++;
            if (currentPage >= objectList.Count) {
                currentPage = 0;
            }
        }
    }

    /** Resets the entire factory and deactivates the catalogue.*/

    public void resetFactory() {
        currentPage = 0;
        unclick();
        mainCanvas.SetActive(false);
    }

    /** Detects whether or not the factory has been clicked.*/

    void OnMouseDown()
    {
        if (!clicked)
        {
            click();
            mainCanvas.SetActive(true);
        }
    }

    /** Changes the state of the factory to unclicked.*/

    public void unclick()
    {
        clicked = false;
    }

    /** Changes the state of the factory to clicked.*/

    public void click() {
        clicked = true;
    }

    /** Produces the currently selected item in the catalogue.*/

    public void produceItem() {
        GameObject newObject = Instantiate(objectList[currentPage]);
        newObject.transform.position = spawnPoint.transform.position;
        resetFactory();
    }

    /** Updates the page based on what item is currently selected. */

    public void updatePage() {
        if (objectList != null) {
            if (objectList[currentPage].GetComponent<InteractiveObject>().interactionName.Length <= 17)
            {
                nameVal.text = objectList[currentPage].GetComponent<InteractiveObject>().interactionName;
            }
            else {
                nameVal.text = objectList[currentPage].GetComponent<InteractiveObject>().interactionName.Substring(0, 17);
            }
            nameVal.color = GameEnvironment.textColor;
            type.text = objectList[currentPage].GetComponent<InteractiveObject>().interactionType;
            type.color = GameEnvironment.textColor;
            subtype.text = objectList[currentPage].GetComponent<InteractiveObject>().interactionSubType;
            subtype.color = GameEnvironment.textColor;
            imageVal.sprite = objectList[currentPage].GetComponent<SpriteRenderer>().sprite;
            if (objectList[currentPage].GetComponent<TimeConstrainer>() != null)
            {
                    bounds.text = "Item Can Only Be Used Between: "
                    + (objectList[currentPage].GetComponent<TimeConstrainer>().hourConstrictA / 10)
                    + (objectList[currentPage].GetComponent<TimeConstrainer>().hourConstrictA % 10)
                    + ":"
                    + (objectList[currentPage].GetComponent<TimeConstrainer>().minuteConstrictA / 10)
                    + (objectList[currentPage].GetComponent<TimeConstrainer>().minuteConstrictA % 10)
                    + "-"
                    + (objectList[currentPage].GetComponent<TimeConstrainer>().hourConstrictB / 10)
                    + (objectList[currentPage].GetComponent<TimeConstrainer>().hourConstrictB % 10)
                    + ":"
                    + (objectList[currentPage].GetComponent<TimeConstrainer>().minuteConstrictB / 10)
                    + (objectList[currentPage].GetComponent<TimeConstrainer>().minuteConstrictB % 10);
            }
            else
            {
                bounds.text = "Can Be Used At Any Time";
            }
        }
    }

}
