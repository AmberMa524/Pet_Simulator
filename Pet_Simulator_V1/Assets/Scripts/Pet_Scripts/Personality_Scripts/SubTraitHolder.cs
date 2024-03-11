using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubTraitHolder : MonoBehaviour
{
    /** Holds the data of a subtrait, which will be used to log data into an item bank.
     The name and value can be altered, but the type cannot.*/

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
