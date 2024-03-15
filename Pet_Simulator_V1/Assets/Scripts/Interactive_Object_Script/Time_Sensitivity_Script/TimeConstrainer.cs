using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeConstrainer : MonoBehaviour
{
    /** This script can be applied to any interactive object to have it
     exist or spawn only within a given time bound. The main prerequisite
    for this is that the time frame is within the same day and does not span
    between multiple days. For example, a bound could be between 3:30 and 5:00, but
    could not be between 17:00 and 1:00. Additionally, the upper and lower bound times
    cannot be the same. */

    //Represents the lower bound hour.
    public int hourConstrictA;

    //Represents the lower bound minute.
    public int minuteConstrictA;

    //Represents the upper bound hour.
    public int hourConstrictB;

    //Represents the upper bound minute.
    public int minuteConstrictB;

    //Represents if the bounds are valid.
    public bool isValidBound;
    
    /** The validity of the selected bound is checked. If the bounds are not
     valid, then the valid bound boolean will be made false. However, if they
    are acceptable, then valid bound boolean will be true.*/
    void Start()
    {
        isValidBound = false;
        if (hourConstrictA < 24
            && hourConstrictB < 24
            && hourConstrictA > 0
            && hourConstrictB > 0
            && minuteConstrictA < 60
            && minuteConstrictB < 60
            && minuteConstrictA >= 0
            && minuteConstrictB >= 0)
        {
            int sumA = (hourConstrictA * 60) + minuteConstrictA;
            int sumB = (hourConstrictB * 60) + minuteConstrictB;
            if (sumA < sumB)
            {
                isValidBound = true;
            }
            else
            {
                isValidBound = false;
            }
        }
        else {
            isValidBound = false;
        }
    }

    /** If the bounds are valid, the game will repeatedly check if the game's time
     frame is within the bounds of the item's time constrainer. If it is not, then
    the item will be destroyed.*/
    void Update()
    {
        if (isValidBound)
        {
            int sumA = (hourConstrictA * 60) + minuteConstrictA;
            int sumB = (hourConstrictB * 60) + minuteConstrictB;
            int sumC = (GameEnvironment.getGameTime().getClock().getHour()*60) + GameEnvironment.getGameTime().getClock().getMinute();

            if (sumC < sumA || sumC > sumB) {
                Destroy(gameObject);
            }
        }
        else {
            Debug.Log("Time Frame Invalid");
        }
    }
}
