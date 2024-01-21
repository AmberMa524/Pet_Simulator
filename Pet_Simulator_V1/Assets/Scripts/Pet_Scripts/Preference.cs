using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preference : MonoBehaviour
{
    /** Represents a preference of a given type. Preferences will exist as children
     of a trait and will be automatically placed into their preference lists. The preference
    value should be given a distinct number indicating how much the pet favours activities or
    items of this specific type. */

    //The name of the preference.
    public string preferenceName;

    //The level of preference for this particular preference.
    public int preferenceValue;

    //The type of preference it is.
    private string preferenceType;

    /** The preference type and value are set to null
     and zero at the start, as it will be manipulated by the
    trait object.*/

    void Start() {

    }

    /** Sets the type of the preference.
     @param newTypeName*/

    public void setType(string newTypeName) {
        preferenceType = newTypeName;
    }

    /** Sets the value of the preference.*/

    public void setValue(int newVal) {
        preferenceValue = newVal;
    }

    /** Gets the type of the preference.
     @return preferenceType*/

    public string getType() {
        return preferenceType;
    }

    /** Gets the value of the preference.
     @return preferenceValue*/

    public int getValue() {
        return preferenceValue;
    }
}
