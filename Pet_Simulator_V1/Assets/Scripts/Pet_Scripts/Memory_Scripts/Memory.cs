using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Since this data will need to be saved and loaded,
 this data is serializable.*/

[System.Serializable]
public class Memory
{
    /** Represents a single memory, which includes an interaction and a time stamp.*/

    //This is the memory's date object.
    [SerializeField] private DateObj date;

    //This is the memory's time object
    [SerializeField] private TimeObj time;

    //This is the memory's interaction object.
    [SerializeField] private Interaction interact;

    /** Memory constructor, which takes in a date, time and interaction
     object in order to build the memory.
    @param dt
    @param tt
    @param it
    */

    public Memory(DateObj dt, TimeObj tt, Interaction it) {
        date = dt;
        time = tt;
        interact = it;
    }

    /**Get the date object.
     @return date.*/

    public DateObj getDate() {
        return date;
    }


    /**Get the time object.
     @return time.*/

    public TimeObj getTime()
    {
        return time;
    }

    /**Get the interaction object.
     @return interaction.*/

    public Interaction getInteraction() {
        return interact;
    }

}
