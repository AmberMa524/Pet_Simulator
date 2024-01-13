using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Manages in-game data such as time, date, and pet data.
 The data can be newly created, or loaded from a pre-existing game.
 The game environment manager is a static class, which comes into use when the game
 starts. The in-game clock only runs when the game is being played.
*/

public class GameEnvironment : MonoBehaviour
{
    //Singular instance of game environment.
    public static GameEnvironment Instance;

    //Determines whether or not the game is paused.
    public static bool paused;

    //Time Data
    public static int hour;
    public static int minute;
    public static int second;

    //Date Data
    public static int year;
    public static int month;
    public static int day;

    //Location (The area in the map where the player last left off).
    public static string location;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        paused = true;
        hour = -1;
        minute = -1;
        second = -1;
        year = -1;
        month = -1;
        day = -1;
        DontDestroyOnLoad(gameObject);
    }

    /** Sets up the starter game data if the game is new.*/

    public static void NewGame() {
        hour = 0;
        minute = 0;
        second = 0;
        year = 1;
        month = 1;
        day = 1;
        location = "Home_Environment_Sprint_001";
    }

    /** Loads preexisting game data into game environment.
     @param hr
     @param min
     @param sec
     @param yr
     @param mt
     @ param dy
    */

    public static void LoadGame(int hr, int min, int sec, 
        int yr, int mt, int dy,
        string loc) {
        hour = hr;
        minute = min;
        second = sec;
        year = yr;
        month = mt;
        day = dy;
        location = loc;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /** 
            If the current game is not paused, the timer will increment
         */
        if (!paused) {

            //Every second, increment the number of seconds.
            //Note that the seconds will run faster in-game than in real life.
            second += 1;
            //Every 60 seconds, a minute passes.
            //Seconds will be reset for the next minute.
            if (second == 60)
            {
                second = 0;
                minute += 1;
            }
            //Every 60 minutes an hour passes.
            //Minutes will be reset for the next hour.
            if (minute == 60)
            {
                minute = 0;
                hour += 1;
            }
            //Every 24 hours, a day passes.
            //Hours will reset for the next day.
            if (hour == 24)
            {
                hour = 0;
                day += 1;
            }
            //Every 30 days, a month passes.
            //Days are reset for the next month.
            if (day > 30)
            {
                day = 1;
                month += 1;
            }
            //Every 12 months, a year passes.
            //Months are reset for the next year.
            if (month > 12)
            {
                month = 1;
                year += 1;
            }
        }

        Debug.Log("Time Is:" + hour + ":" + minute + ":" + second);
        Debug.Log("Date Is:" + year + "/" + month + "/" + day);
        Debug.Log("Paused?:" + paused);
    }

    /** Unpauses the in-game clock so that it may increment.*/

    public static void StartClock() {
        Debug.Log("Game was unpaused");
        paused = false;
    }

    /** Pauses the in-game clock, preventing it from incrementing.*/

    public static void StopClock() {
        Debug.Log("Game was paused");
        paused = true;
    }
}
