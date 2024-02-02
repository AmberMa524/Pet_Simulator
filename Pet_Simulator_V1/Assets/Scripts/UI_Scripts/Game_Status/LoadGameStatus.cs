using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadGameStatus : MonoBehaviour
{

    /** This is a script that is designed to load the status information from
     the game environment. The data is far more concrete, so they could just be
    inputted statically instead of dynamically. */

    //A text object that displays the date.
    public TMP_Text date;

    //A text object that displays the time.
    public TMP_Text time;

    //A text object that displays the location.
    public TMP_Text location;


    /** 
     The date, time, and location found in the game environment will be loaded and displayed
    in their designated text object. This code was placed in the update function, as it may
    be subject to changes in real time.
     */

    void Update()
    {
        GameCalendar currentDate = GameEnvironment.getGameTime().getCal();
        GameClock currentTime = GameEnvironment.getGameTime().getClock();
        string gameEnvLoc = GameEnvironment.location;
        time.text = "Time: " + (currentTime.getHour() / 10) + (currentTime.getHour() % 10)
            + ":" + currentTime.getMinute() / 10
            + currentTime.getMinute() % 10;
        date.text = "Date: " + currentDate.getYear() / 1000 + currentDate.getYear() / 100 + currentDate.getYear() / 10 + currentDate.getYear() % 10 + "/"
            + currentDate.getMonth() / 10 + currentDate.getMonth() % 10 + "/"
            + currentDate.getDay() / 10 + currentDate.getDay() % 10;
        location.text = "Location: " + gameEnvLoc;
    }
}
