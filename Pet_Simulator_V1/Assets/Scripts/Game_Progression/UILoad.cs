using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoad : MonoBehaviour
{
    /** The in game clock freezes whenever a UI screen is loaded. */
    void Start()
    {
        GameEnvironment.StopClock();
    }
}
