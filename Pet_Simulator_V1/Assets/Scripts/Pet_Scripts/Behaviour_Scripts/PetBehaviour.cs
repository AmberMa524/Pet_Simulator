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

    // Start is called before the first frame update
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
        //preferenceManager.printPreferences();
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
        //preferenceManager.printPreferences();
    }
}
