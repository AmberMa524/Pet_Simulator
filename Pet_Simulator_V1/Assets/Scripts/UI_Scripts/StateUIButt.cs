using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StateUIButt : MonoBehaviour
{
    /** Controls the State UI. */

    //The state window.
    public GameObject stateWindow;

    /** Pet State Objects. */

    //First Pet State Object
    public GameObject petState1;

    //Second Pet State Object
    public GameObject petState2;

    //Third Pet State Object
    public GameObject petState3;

    //Fourth Pet State Object
    public GameObject petState4;

    //Fifth Pet State Object
    public GameObject petState5;

    //Represents a differnt page of states.
    public List<List<State>> statePage;

    //List of pet state objects.
    public List<GameObject> petStates;

    //The current page number.
    public int pageNum;


    /** Deactivates the window and adds all of the state objects. */

    void Start()
    {
        deactivate();
        pageNum = 0;
        petStates = new List<GameObject>();
        petStates.Add(petState1);
        petStates.Add(petState2);
        petStates.Add(petState3);
        petStates.Add(petState4);
        petStates.Add(petState5);
    }

    void Update() {
        updateStateValues();
        updateDisplay();
    }

    /** Activates the state window. */

    public void activate() {
        stateWindow.SetActive(true);
    }

    /** Deactivates the state window. */

    public void deactivate() {
        stateWindow.SetActive(false);
    }


    /**Updates the state pages in case they have changed.*/

    public void updateStateValues() {
        if (GameEnvironment.currentGame.currentStateList != null) {
            statePage = new List<List<State>>();
            for (int i = 0; i < GameEnvironment.currentGame.currentStateList.Count; i += petStates.Count) {
                List<State> statelist = new List<State>();
                for (int j = 0; j < petStates.Count && j + i < GameEnvironment.currentGame.currentStateList.Count; j++) {
                    statelist.Add(GameEnvironment.currentGame.currentStateList[j + i]);
                }
                statePage.Add(statelist);
            }
        }
    }

    /** Displays current state screen. */

    public void updateDisplay() {
        if (statePage != null && statePage.Count != 0) {
            List<State> currentStateList = statePage[pageNum];
            for (int i = 0; i < petStates.Count; i++) {
                if (i >= currentStateList.Count)
                {
                    petStates[i].SetActive(false);
                }
                else {
                    GameObject nameObj = petStates[i].gameObject.transform.GetChild(0).gameObject;
                    GameObject meterObj = petStates[i].gameObject.transform.GetChild(1).gameObject;
                    nameObj.GetComponent<TMP_Text>().text = currentStateList[i].stateName;
                    meterObj.GetComponent<Slider>().value = (float) currentStateList[i].stateLevel/State.MAX_LEVEL;
                }
            }
        }
    }

    /** Changes the page number to next page.*/

    public void nextPage() {
        if (statePage != null && statePage.Count != 0) {
            pageNum++;
            if (pageNum >= statePage.Count)
            {
                pageNum = 0;
            }
        }
    }

    /** Changes the page number to previous page.*/

    public void prevPage() {
        if (statePage != null && statePage.Count != 0) {
            pageNum--;
            if (pageNum < 0)
            {
                pageNum = statePage.Count - 1;
            }
        }
    }
}
