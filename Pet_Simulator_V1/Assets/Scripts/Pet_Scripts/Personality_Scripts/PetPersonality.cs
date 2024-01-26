using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetPersonality : MonoBehaviour
{
    /** Controls the creation, generation and management of the pet's personality through
     the setting and getting of its' various traits. Traits are contained in the form of a
    list, which can be called.*/

    /** Contains a list of traits belonging to the pet, which cannot be altered or manipulated
     after being generated. */

    public List<Trait> traitList;

    //A preference manager object, which manages the pet's preferences.
    private PreferenceManager preferenceManager;

    /** Collects all of the traits from the pet and
     puts them into the trait list.*/

    void Start()
    {
        preferenceManager = new PreferenceManager();
        GameObject traitObject = this.gameObject.transform.Find("Traits").gameObject;
        foreach (Transform child in traitObject.transform)
        {
            if (child.tag == "Trait")
            {
                traitList.Add(child.GetComponent<Trait>());
                preferenceManager.addPreference(new Preference(child.GetComponent<Trait>().getType()));
            }
        }
        //preferenceManager.printPreferences();
    }

    /** Returns the list of traits.
     @return traitList*/

    public List<Trait> getTraitList()
    {
        return traitList;
    }

    /** Gets a trait based on a name. */

    public Trait getTrait(string name)
    {
        return traitList.Find(x => x.getType() == name);
    }

    /** Gets the preference manager for the pet's personality.
     @return preferenceManager
    */

    public PreferenceManager getPreferenceManager() {
        return preferenceManager;
    }

    /** Takes in the current interaction and processes it to change the pet's preference.
     The process should involve the evaluation of the frequency of the interaction mixed with
    whether the pet enjoys interactions of the interaction's subtype.
    @param interact
    @param memory
    */

    public void processInteraction(Interaction interact, PetMemories memory) {
        preferenceManager.setPreference(interact);
        //Debug.Log(memory);
    }
}
