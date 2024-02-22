using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubTraitHolder : MonoBehaviour
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

    /** Sets the type of the preference.
     @param newTypeName*/

    public void setType(string newTypeName)
    {
        subTraitType = newTypeName;
    }
}
