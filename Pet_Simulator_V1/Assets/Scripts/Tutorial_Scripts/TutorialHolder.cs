using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TutorialHolder : MonoBehaviour
{
    /** An that holds a tutorial object to be extracted by the ItemBank for
     use throughout the game. This is designed to make implementation for tutorials easier.*/

    //The name of the tutorial.
    [SerializeField] public string tutorialName;

    //An array of sprites for the tutorial.
    [SerializeField] public List<Sprite> screens;

    //Represents the tutorial object that is held by this.
    [SerializeField] private Tutorial tutorialObj;

    void Start() {
        tutorialObj = new Tutorial(tutorialName, screens);
    }

    /** Gets the tutorial of the tutorial holder. */

    public Tutorial getTutorial() {
        return tutorialObj;
    }
}
