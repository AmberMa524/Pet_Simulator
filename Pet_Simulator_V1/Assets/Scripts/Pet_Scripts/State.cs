using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
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

    //Represents the interval of time (in seconds)
    //that it takes for the state to decrement.
    public int interval;

    //The amount of time that has passed between intervals.
    public int time;

    /** State constructor. 
     @param type
     @param name
     @param num*/

    public State(string type, string name, int num) {
        setName(name);
        setType(type);
        setSprite(num);
    }


    /** All needs are completely satiated at the start.
     */

    void Start(){
        stateLevel = MAX_LEVEL;
        time = interval*60;
    }

    /** After a certain period of time, the level of 
     satisfaction in this particular need will slowly go
    down. Once it gets low enough, the pet enters a state
    where they must communicate their need.
    */

    void Update() {
        if (time <= 0)
        {
            if (stateLevel > MIN_LEVEL)
            {
                --stateLevel;
            }
            time = interval*60;
        }
        else {
            --time;
        }
    }

    /** Satisfies a given need/state by a specific amount
     @param inc*/
    public void satiateNeed(int inc) {
        if ((stateLevel + inc) > MAX_LEVEL)
        {
            stateLevel = MAX_LEVEL;
        }
        else {
            stateLevel += inc;
        }
    }

    /** Sets the type of the state.
     @param type*/
    public void setType(string type) {
        stateType = type;
    }

    /**Sets the name of the state */
    public void setName(string name) {
        stateName = name;
    }

    /** Sets the number sprite.
     @param spriteNum*/

    public void setSprite(int spriteNum) {
        spriteNumber = spriteNum;
    }

    /** Returns name. 
     @return stateName*/

    public string getName()
    {
        return stateName;
    }

    /** Returns type. 
    @return stateName*/

    public string getType()
    {
        return stateType;
    }

    /** Returns level. 
    @return stateLevel*/

    public int getLevel() 
    {
        return stateLevel;
    }

    /** Returns sprite. 
    @return spriteNumber*/

    public int getSpriteNumber()
    {
        return spriteNumber;
    }

}
