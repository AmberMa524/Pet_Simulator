using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringValuePair
{
    /** Simple string/int pair item, which is mostly going to just be used for the
     * trait status loading mechanism. This is so that if a trait has more than 5 subtraits,
     those ones can be broken off and placed into another section.
    */

    //Represents the number value of the pair.
    private SubTrait value;

    //Represents the key/name of the pair (used for identification).
    private string key;

    /** String Value Pair constructor, which takes in a string and
     int to define the key and value respectively. 
    @param name
    @param number
    */
    public StringValuePair(string name, SubTrait number) {
        value = number;
        key = name;
    }

    /** Sets the value of pair.
     @param number
    */

    public void setValue(SubTrait number) {
        value = number;
    }

    /** Sets the string/key of the pair.
     @param name
    */

    public void setKey(string name) {
        key = name;
    }

    /** Gets the int value.
     @return value
    */

    public SubTrait getValue() {
        return value;
    }

    /** Gets the key value of the pair.
     @return key
    */

    public string getKey() {
        return key;
    }
}
