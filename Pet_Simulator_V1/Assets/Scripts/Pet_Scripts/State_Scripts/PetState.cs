using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetState : MonoBehaviour
{
    /** Controls the pet's various states contained in their states object.
     it detects which need requires the most attention and communicates to the player
    that need*/

    //Provides a list of states, which can be moved through.
    public List<State> stateList;

    //Provides the current state of the pet.
    //If the pet is in its' basic, idle form,
    //the current state would be null.
    private State currentState;

    //If an unsatiated need is found, this will return true.
    private bool found;

    //Animation Values

    //Manipulates animations for suggestion window.
    private Animator animator;
    //Gets the GFX object that controls the sprite animations.
    public GameObject GFXController;
    //Represents the suggestion window included with the character.
    public GameObject suggestionWindow;

    /** Gets all the various state objects connected to the parent object, and adds
     them to their state list for later calculations and evaluations. The suggestion
    window remains hidden until need is satiated.*/
    void Start()
    {
        animator = GFXController.GetComponent<Animator>();
        stateList = GameEnvironment.currentGame.currentStateList;
        /**
        GameObject stateObject = this.gameObject.transform.Find("States").gameObject;
        foreach(Transform child in stateObject.transform)
        {
            if (child.tag == "State") {
                stateList.Add(child.GetComponent<State>());
            }
        }
        */
        currentState = null;
        hideSuggestion();
        found = false;
    }

    /** If an unsatiated need is found, the suggestion window is
     shown. If not, the program will keep looking for the next unsatiated need.*/
    void Update()
    {
        foreach (State st in stateList) {
            st.decrement();
        }
        if (found)
        {
            showSuggestion();
        }
        else {
            hideSuggestion();
        }
        getCurrentState();
    }

    public void pauseStates()
    {
        foreach (State st in stateList)
        {
            st.pauseState();
        }
    }

    public void unpauseStates() {
        foreach (State st in stateList)
        {
            st.unpauseState();
        }
    }

    /** Checks which state currently has a value of 0, then shows it
     on the screen. If more than one state has a value of 0, then
    the first state chronologically on the list that contains 0
    will be shown. */

    private void getCurrentState() {
        for (int i = 0; i < stateList.Count; i++) {
            if (stateList[i].getLevel() == 0) {
                currentState = stateList[i];
                found = true;
                return;
            }
        }
        found = false;
        currentState = null;
    }

    /** 
     * Changes the sprite of the suggestion window. Suggestion window is shown.
     */

    private void showSuggestion() {
        animator.SetInteger("Animation_Index", currentState.getSpriteNumber());
        suggestionWindow.SetActive(true);
    }

    /** 
     * Hides the suggestion window.
     */

    private void hideSuggestion()
    {
        suggestionWindow.SetActive(false);
    }

    /** Processes an interaction by checking if the type of the interaction matches that of the
     type of state. It then satiates the pet's particular need by a basic factor (will be subject
    to change as the pet's interaction calculation mechanisms change).
    @param interact*/

    public void processInteraction(Interaction interact) {
        for (int i = 0; i < stateList.Count; i++)
        {
            if (interact.getType() == stateList[i].getType()) {
                stateList[i].satiateNeed(stateList[i].getMaxLevel());
            }
        }
    }

    /** Returns true if an unsatiated need is found inside of the pet. 
     @return found
    */

    public bool isFound() {
        return found;
    }

    /** Returns the current state of the pet.
     @return currentState
    */

    public State getState() {
        return currentState;
    }

    /** Add new state to the state list. */

    public void addState(State newState) {
        stateList.Add(newState);
    }
}
