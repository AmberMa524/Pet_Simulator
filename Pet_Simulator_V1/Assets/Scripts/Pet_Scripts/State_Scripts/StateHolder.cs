using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHolder : MonoBehaviour
{

    /** Represents the state of the pet (hungry, sleepy, bored, energized, etc.), which
     represents a need for the pet to do something (eat, sleep, etc.). The state of the pet
    will change its' behavior (the pet will communicate this need if it gets low enough). */

    //Represents the maximum level a state/need would be.

    public const int MAX_LEVEL = 10;

    //Repersents the minimum level a state/need would be.

    public const int MIN_LEVEL = 0;

    //Refers to the name of the state.

    public string stateName;

    //Determines the type of state/need it is.

    public string stateType;

    //Represents the sprite that indicates

    public int spriteNumber;

    //Determines how much this need is satiated.
    public int stateLevel;

    //If the game is paused, the state will not update.
    public bool pause;

    //Represents the interval of time (in seconds)
    //that it takes for the state to decrement.
    public int interval;

    //The amount of time that has passed between intervals. All needs are completely satiated at the start.
    public int time;

    public State stateItem;

    void Start() {
        stateItem = new State(stateName, stateType, spriteNumber);
    }
}
