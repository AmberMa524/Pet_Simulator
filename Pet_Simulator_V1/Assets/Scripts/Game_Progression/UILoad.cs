using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void terminateGame() {
        GameEnvironment.terminateGame();
    }
}
