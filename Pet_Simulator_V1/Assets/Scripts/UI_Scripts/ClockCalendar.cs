using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockCalendar : MonoBehaviour
{
    //Represents the Text
    public TMP_Text clock_Text;
    public TMP_Text calendar_Text;

    // Update is called once per frame
    void Update()
    {
        GameTime gt = GameEnvironment.getGameTime();
        GameCalendar gc = gt.getCal();
        GameClock gcl = gt.getClock();
        clock_Text.text = "" + (gcl.getHour()/10) + (gcl.getHour()%10) 
            + ":" + gcl.getMinute()/10 
            + gcl.getMinute()%10;
        calendar_Text.text = "" + gc.getYear()/1000 + gc.getYear()/100 + gc.getYear()/10 + gc.getYear()%10 + "/" 
            + gc.getMonth()/10 + gc.getMonth()%10 + "/" 
            + gc.getDay()/10 + gc.getDay()%10;
    }
}