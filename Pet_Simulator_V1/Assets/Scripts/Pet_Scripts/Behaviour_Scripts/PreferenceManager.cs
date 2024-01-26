using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferenceManager
{

    /** Is used to catalogue and alter the preferences of the pet over the course of the game.
     The preferences will relate to the specific interactions of different categories. The
    category of an interaction is referred to as its' type, which relates to a particular need-action.*/

    /** Maintains a list of preferences, which can be added to during the game.*/

    List<Preference> preferenceList;

    /** Preference Manager default constructor. */
    public PreferenceManager()
    {
        preferenceList = new List<Preference>();
    }

    /** Adds a preference to the preference list.
     @param newPref
    */

    public void addPreference(Preference newPref) {
        preferenceList.Add(newPref);
    }

    /** Takes in an interaction and attempts to find the item on the list that matches
     the type of that interaction with an interaction category in one of the preference
    objects. Then, it sets the interaction to that value. 
    @param newValue
    */

    public void setPreference(Interaction newValue) {
        preferenceList.Find(x => x.getType() == newValue.getType()).setInteraction(newValue);
    }

    /** This script will be used for testing purposes to ensure that the preference manager 
     is loading properly.
    */

    public void printPreferences() {
        for (int i = 0; i < preferenceList.Count; i++) {
            string typeVal = preferenceList[i].getType();
            string output = "Preference " + i + ": " + typeVal + "\n";
            if (preferenceList[i].getInteraction() == null)
            {
                //Debug.Log("Is Null");
            }
            else {
                output += "Interaction Name: " + preferenceList[i].getInteraction().getName() + "\n";
            }
            Debug.Log(output);
            //Debug.Log("Preference " + i + ": " + typeVal + "\n"
            //    + "Interaction Name: " + preferenceList[i].getInteraction().getName() + "\n");
        }
    }
}
