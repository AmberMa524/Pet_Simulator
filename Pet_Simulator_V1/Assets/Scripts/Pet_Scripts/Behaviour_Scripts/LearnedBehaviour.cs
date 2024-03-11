using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Since this data will need to be saved and loaded,
 this data is serializable.*/

[System.Serializable]
public class LearnedBehaviour
{
    /** If the pet is interacted with enough, it will begin to pick up on
     repeated behaviours. It will end up suggesting specific interactions as a result
    at that time depending on whether or not they like those behaviours or not and 
    the median average time the player performs this action in recent memory.
    */

    //Represents the average time action is performed.
    [SerializeField] private TimeObj timeStamp;

    //Represents the action learned.
    [SerializeField] private Interaction action;

    /** Learned behavior constructor, which requires the specification of
     the time stamp and the interaction in order to be constructed.*/
    public LearnedBehaviour(TimeObj time, Interaction interact)
    {
        setTime(time);
        setAction(interact);
    }

    /** Gets the average time value.
     @return timeStamp*/

    public TimeObj getTime() {
        return timeStamp;
    }

    /** Gets the interaction.
     @return action*/

    public Interaction getAction() {
        return action;
    }

    /** Sets the average time value.
     @param time*/

    public void setTime(TimeObj time) {
        timeStamp = time;
    }

    /** Sets the action for this object. 
     @param interact*/

    public void setAction(Interaction interact)
    {
        action = interact;
    }
}
