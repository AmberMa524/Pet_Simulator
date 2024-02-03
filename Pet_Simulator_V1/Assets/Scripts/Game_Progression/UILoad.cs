using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoad : MonoBehaviour
{
    /** The in game clock freezes whenever a UI screen is loaded. 
     If the state is paused and the pet's physics is temporarily
    shut down. */
    void Start()
    {
        GameEnvironment.StopClock();
        GameObject[] states = GameObject.FindGameObjectsWithTag("State");
        for (int i = 0; i < states.Length; i++) {
            states[i].GetComponent<State>().pauseState();
        }
        GameObject.FindGameObjectWithTag("Pet").GetComponent<Rigidbody>().useGravity = false;
        GameObject.FindGameObjectWithTag("Pet").GetComponent<PetMovement>().pauseMovement();
        //MusicController.PauseMusic();
        //GameObject.FindGameObjectWithTag("Pet").GetComponent<PetBehaviour>().getPreferenceManager().printPreferences();
    }

    public void returnToGame() {
        SceneManager.LoadScene(GameEnvironment.getLocation());
    }

    public void terminateGame() {
        GameEnvironment.terminateGame();
        MusicController.StopMusic();
    }
}
