using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialUIHandler : MonoBehaviour
{
    /** Controls what tutorials get loaded on the tutorial loading screen.*/

    //First Tutorial Object
    public GameObject tutorial_001;

    //Second Tutorial Object
    public GameObject tutorial_002;

    //Third Tutorial Object
    public GameObject tutorial_003;

    //Represents a differnt page of states.
    public List<List<Tutorial>> tutorialPage;

    //List of tutorial objects.
    public List<GameObject> tutorialObjects;

    //The current page number.
    public int pageNum;

    /** Deactivates the window and adds all of the state objects. */

    void Start()
    {
        pageNum = 0;
        tutorialPage = new List<List<Tutorial>>();
        tutorialObjects = new List<GameObject>();
        tutorialObjects.Add(tutorial_001);
        tutorialObjects.Add(tutorial_002);
        tutorialObjects.Add(tutorial_003);
    }

    void Update() {
        Debug.Log(tutorialPage.Count);
        updateTutorialValues();
        updateDisplay();
    }

    /**Updates the state pages in case they have changed.*/

    public void updateTutorialValues()
    {
        if (ItemBank.tutorialList != null)
        {
            tutorialPage = new List<List<Tutorial>>();
            for (int i = 0; i < ItemBank.tutorialList.Count; i += tutorialObjects.Count)
            {
                List<Tutorial> tutorialList = new List<Tutorial>();
                for (int j = 0; j < tutorialObjects.Count && j + i < ItemBank.tutorialList.Count; j++)
                {
                    tutorialList.Add(ItemBank.tutorialList[j + i]);
                }
                tutorialPage.Add(tutorialList);
            }
        }
    }

    /** Displays current state screen. */

    public void updateDisplay()
    {
        if (tutorialPage != null && tutorialPage.Count != 0)
        {
            List<Tutorial> currentTutorialList = tutorialPage[pageNum];
            for (int i = 0; i < tutorialObjects.Count; i++)
            {
                if (i >= currentTutorialList.Count)
                {
                    tutorialObjects[i].SetActive(false);
                }
                else
                {
                    tutorialObjects[i].GetComponent<TMP_Text>().text = currentTutorialList[i].getName();
                }
            }
        }
    }

    /** Changes the page number to next page.*/

    public void nextPage()
    {
        if (tutorialPage != null && tutorialPage.Count != 0)
        {
            pageNum++;
            if (pageNum >= tutorialPage.Count)
            {
                pageNum = 0;
            }
        }
    }

    /** Changes the page number to previous page.*/

    public void prevPage()
    {
        if (tutorialPage != null && tutorialPage.Count != 0)
        {
            pageNum--;
            if (pageNum < 0)
            {
                pageNum = tutorialPage.Count - 1;
            }
        }
    }
}
