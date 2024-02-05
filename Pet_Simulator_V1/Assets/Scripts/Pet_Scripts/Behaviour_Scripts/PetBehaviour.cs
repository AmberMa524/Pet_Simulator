using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBehaviour : MonoBehaviour
{
    /** Manages the pet's preferences and learned behaviors. */

    //A preference manager object, which manages the pet's preferences.
    private PreferenceManager preferenceManager;

    //A learned behaviour manager that manages all of the pet's learned behaviours.
    private LearnedBehaviourManager learnedBehaviourManager;

    //Represents the pet's thought bubble, which will serve as its' prime behavior.
    public GameObject thoughtWindow;

    /** Sets up the learned behavior and preference managers. Preferences are
     developed based on traits found in the pet's data.*/
    void Start()
    {
        learnedBehaviourManager = new LearnedBehaviourManager();
        preferenceManager = new PreferenceManager();
        GameObject traitObject = this.gameObject.transform.Find("Traits").gameObject;
        foreach (Transform child in traitObject.transform)
        {
            if (child.tag == "Trait")
            {
                preferenceManager.addPreference(new Preference(child.GetComponent<Trait>().getType()));
            }
        }
    }

    /** Every second, the pet will attempt to perform a random action. */

    void Update() {
        performAction();
    }

    /** Gets the preference manager for the pet's personality.
     @return preferenceManager
    */

    public PreferenceManager getPreferenceManager()
    {
        return preferenceManager;
    }

    /** Takes in the current interaction and processes it to change the pet's preference.
     The process should involve the evaluation of the frequency of the interaction mixed with
    whether the pet enjoys interactions of the interaction's subtype. A learned behaviour may
    be developed depeding on the frequency of the act, and a median average time may be determined,
    by the pet's memory of it.
    @param interact
    @param memory
    */

    public void processInteraction(Interaction interact, PetMemories memory, TimeObj time)
    {
        LearnedBehaviour newBehaviour = new LearnedBehaviour(time, interact);
        preferenceManager.setPreference(interact);
        learnedBehaviourManager.addLearnedBehaviour(newBehaviour);
        learnedBehaviourManager.printBehaviours();
    }

    /** Utilizing the information found in the pet's state data, preference manager,
     and learned behavior manager, the pet will suggest an interaction type. */

    public void performAction() {
        //Check if a pet has entered a state
        PetState currentPetState = gameObject.GetComponent<PetState>();
        if (currentPetState.isFound())
        {
            //If the pet is currently in a state, check what state it is.
            //Then, depending on the type of state, check if the pet has any particular
            //preference within that state.
            string type = currentPetState.getState().getType();
            Preference prefByType = preferenceManager.getPreferenceByType(type);
            if (prefByType != null)
            {
                //If the preference has an interaction associated with it, then
                //display the sprite for that interaction on the pet's window.
                if (prefByType.getInteraction() != null)
                {
                    thoughtWindow.SetActive(true);
                    GameObject.FindGameObjectWithTag("ThoughtElements").GetComponent<ThoughtSpriteChange>().ChangeSprite(prefByType.getInteraction().getSprite());
                }
                else {
                    thoughtWindow.SetActive(false);
                }
            }
            else {
                thoughtWindow.SetActive(false);
            }
            //If so, then show the thought window with the preferred interaction on it.
            //If not, then do not show the thought window (keep hidden).
        }
        else {
            thoughtWindow.SetActive(false);
            //If the pet is not in a state, then check if there is a regularly scheduled behavior for that
            //time. If so, then show the interaction for that learned behavior on the thought bubble.
            //If not, then keep the thought bubble hidden.
        }
    }
}
