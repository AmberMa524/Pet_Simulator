using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Since this data will need to be saved and loaded,
 this data is serializable.*/

[System.Serializable]
public class GameCalendar
{
    /** Manages the current date in the game including
    days, months, and years.*/

    //Const determining the maximum months in a year.
    [SerializeField] private const int MAX_MONTHS = 12;

    //Const determining the maximum days in a month.
    [SerializeField] private const int MAX_DAYS = 30;

    //Represents the years gone by.

    [SerializeField] private int timeYear;

    //Represents the months gone by.

    [SerializeField] private int timeMonth;

    //Represents the days gone by.

    [SerializeField] private int timeDay;

    /** Game calendar constructor. The default date will be
     01/01/0001. The calendar may be set to a particular date.
    */

    public GameCalendar()
    {
        resetCalendar();
    }

    /** Increments the day counter by one.
     Every 30 days, a month passes.
     Every 12 months a year passes.
    Months and Days will be reset once they reach their
    maximum value.
     */

    public void incrementDay() {
        timeDay += 1;
        //Every 30 days, a month passes.
        //Days are reset for the next month.
        if (timeDay > MAX_DAYS)
        {
            timeDay = 1;
            timeMonth += 1;
        }
        //Every 12 months, a year passes.
        //Months are reset for the next year.
        if (timeMonth > MAX_MONTHS)
        {
            timeMonth = 1;
            timeYear += 1;
        }
    }

    /** Gets the current year on the calendar.
     @return timeYear
    */

    public int getYear()
    {
        return timeYear;
    }

    /** Gets the current month on the calendar.
     @return timeMonth
    */

    public int getMonth()
    {
        return timeMonth;
    }

    /** Gets the current day on the calendar.
     @return timeDay
    */

    public int getDay()
    {
        return timeDay;
    }

    /** Resets the calendar to default.*/

    public void resetCalendar()
    {
        timeYear = 1;
        timeMonth = 1;
        timeDay = 1;
    }

    /**Manually sets the date.
     @param yr
     @param mt
     @param dy*/

    public void setCalendar(int yr, int mt, int dy)
    {
        timeYear = yr;
        timeMonth = mt;
        timeDay = dy;
    }
}
