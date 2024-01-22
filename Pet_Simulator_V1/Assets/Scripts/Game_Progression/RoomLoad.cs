using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoad : MonoBehaviour
{
    /** The clock starts as soon as the room loads again.*/
    void Start()
    {
        GameEnvironment.StartClock();
    }

}
