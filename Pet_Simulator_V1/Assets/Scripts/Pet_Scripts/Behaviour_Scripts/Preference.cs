using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Preference
{
    /** Represents a preferred interaction-type pair. This will be used for organizing the pet's
     preferences based on the category of the preference (taste, sleep music, athletic, etc.).
    These will be catalogued in a preference manager, which will contain all of the preference data.
    */

    //Interaction object that represents the interaction that the pet prefers.
    [SerializeField] private Interaction interaction;

    //String that indicates the category of interaction.
    [SerializeField] private string type;
    
    /**Default preference controller.*/

    public Preference() {

    }

    /** Preference constructor that takes in a type object.
     @param newType
    */

    public Preference(string newType) {
        setType(newType);
    }

    /** Sets the preference of the object. 
     @param newType
     @param newInteract
    */

    public void setPreference(string newType, Interaction newInteract)
    {
        setType(newType);
        setInteraction(newInteract);
    }

    /** Sets the type of the preference. 
     @param newType
    */

    public void setType(string newType) {
        type = newType;
    }

    /** Sets the interaction associated with this preference type. 
     @param newInteract*/

    public void setInteraction(Interaction newInteract) {
        interaction = newInteract;
    }

    /** Returns the preference's type.
     @return type
    */

    public string getType() {
        return type;
    }

    /** Returns the interaction currently associated with the preference.
     @return interaction
    */

    public Interaction getInteraction() {
        return interaction;
    }
}
