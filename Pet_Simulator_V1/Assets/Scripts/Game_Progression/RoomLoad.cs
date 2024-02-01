using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoad : MonoBehaviour
{
    /** The clock starts as soon as the room loads again.
     All the states reawaken, and the pet's physics kick in again.*/

    void Start()
    {
        GameEnvironment.StartClock();
        GameObject[] states = GameObject.FindGameObjectsWithTag("State");
        for (int i = 0; i < states.Length; i++)
        {
            states[i].GetComponent<State>().unpauseState();
        }
        GameObject.FindGameObjectWithTag("Pet").GetComponent<Rigidbody>().useGravity = true;
    }

}
