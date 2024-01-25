using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Manages a calendar and a clock to work in tandum with
 each other.*/

public class GameTime
{
    //Represents the maximum hours in a day.
    private const int MAX_HOUR = 24;

    //Game Calendar for time object.
    private GameCalendar mainGCal;

    //Game Clock for the time object.
    private GameClock mainGClock;

    /** Instantiates the clock and the calendar for the time.*/

    public GameTime() {
        mainGCal = new GameCalendar();
        mainGClock = new GameClock();
    }

    public void UpdateTime() {
        mainGClock.UpdateClock();
        if (mainGClock.getHour() == MAX_HOUR) {
            mainGCal.incrementDay();
        }
    }

    /** Returns the calendar. 
     @return mainGCal
    */

    public GameCalendar getCal() {
        return mainGCal;
    }

    /** Returns the clock
     @return mainGClock */

    public GameClock getClock() {
        return mainGClock;
    }

    /** */
    public void resetTime() {
        mainGClock.resetClock();
        mainGCal.resetCalendar();
    }

    /** Starts the time. */

    public void startTime() {
        mainGClock.startClock();
    }

    /** Pauses the time */

    public void pauseTime() {
        mainGClock.stopClock();
    }
}
