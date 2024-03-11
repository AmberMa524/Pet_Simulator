using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHolder : MonoBehaviour
{

    /** Holds a state, which will be passed into the item bank. All of the information of
     this state type will be written into the item bank for later use in the game as a template.*/

    //Refers to the name of the state.

    public string stateName;

    //Determines the type of state/need it is.

    public string stateType;

    //Represents the sprite that indicates

    public int spriteNumber;

    //Represents the interval of time (in seconds)
    //that it takes for the state to decrement.
    public int interval;

    //The state that is contained by this state holder.
    public State stateItem;

    void Start() {
        stateItem = new State(stateType, stateName, spriteNumber, interval);
    }
}
