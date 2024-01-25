using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateObj
{
    /** Represents a date. This includes a day, month, and year.
     This is for the Memory object for cataloguing the date.*/

    //Represents the amount of days passed.
    private int day;

    //Represents the amount of months passed.
    private int month;

    //Represents the amount of years passed.
    private int year;

    /**Date object constructor.
     * @param dy
       @param mt
       @param yr
    */

    public DateObj(int dy, int mt, int yr)
    {
        day = dy;
        month = mt;
        year = yr;
    }

    /** Gets the day. 
     @return day
    */

    public int getDay()
    {
        return day;
    }

    /** Gets the month. 
     @return month
    */

    public int getMonth()
    {
        return month;
    }

    /** Gets the year. 
     @return year
    */

    public int getYear()
    {
        return year;
    }

    /** Sets the days. 
     @param dy
    */

    public void setDay(int dy)
    {
        day = dy;
    }

    /** Sets the month. 
     @param mt
    */

    public void setMinute(int mt)
    {
        month = mt;
    }

    /** Sets the year. 
     @param yr
    */

    public void setYear(int yr)
    {
        year = yr;
    }
}
