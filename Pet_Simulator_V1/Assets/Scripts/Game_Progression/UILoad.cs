using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoad : MonoBehaviour
{
    /** The in game clock freezes whenever a UI screen is loaded. 
     If the state is paused and the pet's physics is temporarily
    shut down. */

    //If the UI has loaded, return true.
    public bool hasLoaded;

    /** If the UI loads, stop the pet and the in-game clock.*/

    void Start()
    {
        GameEnvironment.StopClock();
        GameObject.FindGameObjectWithTag("Pet").GetComponent<Rigidbody>().useGravity = false;
        GameObject.FindGameObjectWithTag("Pet").GetComponent<PetMovement>().pauseMovement();
    }

    /** If the pet has loaded, then pause the pet's states, then confirm that
     the pet has loaded.*/

    void Update() {
        if (!hasLoaded)
        {
            GameObject.FindGameObjectWithTag("Pet").GetComponent<PetState>().pauseStates();
            hasLoaded = true;
        }
    }

    /** Changes the scene to the current location. */

    public void returnToGame() {
        SceneManager.LoadScene(GameEnvironment.getLocation());
    }

    /** Stops the game and music, then loads the game data.*/

    public void terminateGame() {
        GameEnvironment.terminateGame();
        MusicController.StopMusic();
        GameEnvironment.loadGameDataFromFile();
    }
}
