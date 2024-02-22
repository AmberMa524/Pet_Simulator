using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoad : MonoBehaviour
{
    /** The in game clock freezes whenever a UI screen is loaded. 
     If the state is paused and the pet's physics is temporarily
    shut down. */

    public bool hasLoaded;

    void Start()
    {
        GameEnvironment.StopClock();
        GameObject.FindGameObjectWithTag("Pet").GetComponent<Rigidbody>().useGravity = false;
        GameObject.FindGameObjectWithTag("Pet").GetComponent<PetMovement>().pauseMovement();
        //MusicController.PauseMusic();
        //GameObject.FindGameObjectWithTag("Pet").GetComponent<PetBehaviour>().getPreferenceManager().printPreferences();
    }

    void Update() {
        if (!hasLoaded)
        {
            GameObject.FindGameObjectWithTag("Pet").GetComponent<PetState>().pauseStates();
            hasLoaded = true;
        }
    }

    public void returnToGame() {
        SceneManager.LoadScene(GameEnvironment.getLocation());
    }

    public void terminateGame() {
        GameEnvironment.terminateGame();
        MusicController.StopMusic();
        GameEnvironment.loadGameDataFromFile();
    }
}
