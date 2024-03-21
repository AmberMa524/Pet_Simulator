using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialData : MonoBehaviour
{
    /** Inserts data in the tutorial object. */

    //Represents the tutorial value currently populating this.
    public int tutorialIndex;

    public Tutorial tutorialValue;

    //Represents the name of the tutorial screen.
    public string tutorialScreenTitle;

    /** Changes the scene to the tutorial screen, and passes the tutorial value to the game environment. */

    public void changeToTutorialScreen() {
        if (tutorialValue != null) {
            GameEnvironment.currentTutorial = ItemBank.tutorialList[tutorialIndex];
            SceneManager.LoadScene(tutorialScreenTitle);
        }
    }
}
