using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/** The game slots will be dynamically generated using the saved data in
 the game's files, which will be passed in upon being clicked.*/

public class GameSlot : MonoBehaviour
{
    /** An item that visually represents a game. If blank,
     then the data in the slot will not be found.*/

    //Game data to be passed on to the GameEnvironment load function.
    public int slotIndex;
    //Title text.
    public TMP_Text fn_text;
    //Time Stamp text.
    public TMP_Text ts_text;
    //Location text.
    public TMP_Text lc_text;

    /** Fills the data in the game slot with data
     from the designated game data.
    */
    void Update()
    {
        if (GameEnvironment.currentGameData[slotIndex] != null) {
            if (GameEnvironment.currentGameData[slotIndex].isEmpty)
            {
                fn_text.text = "[New Game]";
                ts_text.text = "";
                lc_text.text = "";
            }
            else {
                int gameNum = slotIndex + 1;
                fn_text.text = "Game: #" + gameNum;
                GameTime gt = GameEnvironment.currentGameData[slotIndex].currentTimeDate;
                GameCalendar gc = gt.getCal();
                GameClock gcl = gt.getClock();
                ts_text.text = "" + (gcl.getHour() / 10) + (gcl.getHour() % 10)
                    + ":" + gcl.getMinute() / 10
                    + gcl.getMinute() % 10 + "\n" + gc.getYear() / 1000 + gc.getYear() / 100 + gc.getYear() / 10 + gc.getYear() % 10 + "/"
                    + gc.getMonth() / 10 + gc.getMonth() % 10 + "/"
                    + gc.getDay() / 10 + gc.getDay() % 10;
                lc_text.text = GameEnvironment.currentGameData[slotIndex].currentLocation;
            }
        }
    }
}
