using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Since this data will need to be saved and loaded,
 this data is serializable.*/

[System.Serializable]
public class GameTime
{
    /** Manages a calendar and a clock to work in tandum with
    each other.*/

    //Represents the maximum hours in a day.
    private const int MAX_HOUR = 24;

    //Game Calendar for time object.
    [SerializeField] private GameCalendar mainGCal;

    //Game Clock for the time object.
    [SerializeField] private GameClock mainGClock;

    /** Instantiates the clock and the calendar for the time.*/

    public GameTime() {
        mainGCal = new GameCalendar();
        mainGClock = new GameClock();
    }

    /** Updates the time by incrementing the clock.
     if the clock hits the maximum hour, a day will pass.*/

    public void UpdateTime() {
        mainGClock.UpdateClock();
        if (mainGClock.getHour() == MAX_HOUR) {
            mainGClock.setHour(0);
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

    /** Resets the time and date to defaults.*/
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
