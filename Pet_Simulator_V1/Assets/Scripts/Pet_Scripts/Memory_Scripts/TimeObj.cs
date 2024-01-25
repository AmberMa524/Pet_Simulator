using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObj
{
    /** Represents a time stamp. This includes a second, minute, and hour.
     This is for the Memory object for cataloguing the time.*/

    //Represents the amount of seconds passed.
    private int second;

    //Represents the amount of minutes passed.
    private int minute;

    //Represents the amount of hours passed.
    private int hour;

    /**Time object constructor.
     * @param sec
       @param min
       @param hr
    */

    public TimeObj(int sec, int min, int hr) {
        second = sec;
        minute = min;
        hour = hr;
    }

    /** Gets the second. 
     @return second
    */

    public int getSecond() {
        return second;
    }

    /** Gets the minute. 
     @return minute
    */

    public int getMinute()
    {
        return minute;
    }

    /** Gets the hour. 
     @return hour
    */

    public int getHour()
    {
        return hour;
    }

    /** Sets the seconds. 
     @param sec
    */

    public void setSecond(int sec) {
        second = sec;
    }

    /** Sets the minutes. 
     @param min
    */

    public void setMinute(int min)
    {
        minute = min;
    }

    /** Sets the hours. 
     @param hr
    */

    public void setHour(int hr)
    {
        hour = hr;
    }
}
