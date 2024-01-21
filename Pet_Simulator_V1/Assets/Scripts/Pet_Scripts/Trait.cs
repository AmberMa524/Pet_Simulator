using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trait : MonoBehaviour
{
    /** Represents a particular trait (academic, taste, etc.), which can contain a series of
     sub-preferences. When a sub-preference is included in the preference list, it will automatically
    be set with the trait's type.*/

    //
    public const int PREFERENCE_RANGE = 100;
    public string type;
    public List<Preference> preferenceList;

    void Start() {
        setUpPreferenceTypes();
        randomTraitGeneration();
    }

    public void randomTraitGeneration() {
        //List<int> randomlyGeneratedInts;
        for (int i = 0; i < preferenceList.Count; i++) {
            int randomNumber = Random.Range(0, PREFERENCE_RANGE);
            Debug.Log("Random Number Is" + randomNumber);
            preferenceList[i].setValue(randomNumber);
        }
    }

    private void setUpPreferenceTypes()
    {
        if (preferenceList.Count != 0) {
            for (int i = 0; i < preferenceList.Count; i++) {
                preferenceList[i].setType(type);
            }
        }
    }
}
