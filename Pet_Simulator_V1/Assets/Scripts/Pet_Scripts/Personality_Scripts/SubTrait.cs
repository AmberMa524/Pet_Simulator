using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Since this data will need to be saved and loaded,
 this data is serializable.*/

[System.Serializable]
public class SubTrait
{
    /** Represents a preference of a given type. Preferences will exist as children
     of a trait and will be automatically placed into their preference lists. The preference
    value should be given a distinct number indicating how much the pet favours activities or
    items of this specific type. */

    //The name of the sub trait.
    public string subTraitName;

    //The level of sub trait for this particular preference.
    public int subTraitValue;

    //The type of preference it is.
    private string subTraitType;

    public SubTrait() { }

    public SubTrait(string name, int value) {
        subTraitName = name;
        subTraitValue = value;
    }

    /** Sets the type of the preference.
     @param newTypeName*/

    public void setType(string newTypeName) {
        subTraitType = newTypeName;
    }

    /** Sets the value of the subTrait.
     @param newVal
    */

    public void setValue(int newVal) {
        subTraitValue = newVal;
    }

    /** Gets the name of the subTrait.
        @param newName
        */

    public void setName(string newName)
    {
        subTraitName = newName;
    }

    /** Gets the type of the subTrait.
     @return preferenceType*/

    public string getType() {
        return subTraitType;
    }

    /** Gets the value of the subTrait.
     @return preferenceValue*/

    public int getValue() {
        return subTraitValue;
    }

    /** Gets the name of the subTrait.
     @return subTraitName
    */

    public string getName() {
        return subTraitName;
    }
}
