using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Manages the current time in the game including
 seconds, minutes, and hours.*/

[System.Serializable]
public class GameClock
{
    [SerializeField] private const int SECOND_INCREMENT = 60;

    //Const determining the maximum minutes in an hour.
    [SerializeField] private const int MAX_MINUTES = 60;

    //Const determining the maximum seconds in a minute.
    [SerializeField] private const int MAX_SECONDS = 60;

    //Is clock stopped?

    [SerializeField] private bool paused;

    //Hours

    [SerializeField] private int timeHour;

    //Minutes

    [SerializeField] private int timeMinute;

    //Seconds

    [SerializeField] private int timeSecond;

    /** Game clock constructor. The default time values
     will be set to 0. The clock will automatically be stopped upon
    creation.
    */

    public GameClock()
    {
        stopClock();
        resetClock();
    }

    /** Checks if the clock is paused. If so, a second will not
     pass. However, if the clock is unpaused, a second will pass.*/

    public void UpdateClock()
    {
        if (!isPaused()) {
            timeSecond += SECOND_INCREMENT;
            //Every second, increment the number of seconds.
            //Note that the seconds will run faster in-game than in real life.
            if (timeSecond == MAX_SECONDS)
            {
                timeSecond = 0;
                timeMinute += 1;
            }
            //Every 60 minutes an hour passes.
            //Minutes will be reset for the next hour.
            if (timeMinute == MAX_MINUTES)
            {
                timeMinute = 0;
                timeHour += 1;
            }
        }
    }

    /** Gets the current hour on the clock.
     @return timeHour
    */

    public int getHour() {
        return timeHour;
    }

    /** 
     Gets the current minute on the clock.
     @return timeMinute
     */

    public int getMinute() {
        return timeMinute;
    }

    /** 
     Gets the current second on the clock.
     @return timeSecond
     */

    public int getSecond() {
        return timeSecond;
    }

    /** 
     Sets the current hour on the clock.
     @return timeSecond
     */

    public void setHour(int newhr)
    {
        timeHour = newhr;
    }

    /** Resets the clock to default.*/

    public void resetClock() {
        timeHour = 0;
        timeMinute = 0;
        timeSecond = 0;
    }

    /** Sets the clock to a specific time.
     @param hr
     @param min
     @param sec
    */

    public void setClock(int hr, int min, int sec) {
        timeHour = hr;
        timeMinute = min;
        timeSecond = sec;
    }

    /** Unpauses the clock. */

    public void startClock() {
        paused = false;
    }

    /** Pauses the clock. */

    public void stopClock() {
        paused = true;
    }

    /** Returns true if clock is paused.*/

    public bool isPaused() {
        return paused;
    }

}
