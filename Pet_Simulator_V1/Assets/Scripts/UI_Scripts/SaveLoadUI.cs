using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadUI : MonoBehaviour
{

    /** Controls the UI on the load screen. */

    //Represents the save screen.
    public GameObject saveScreen;

    //Represents the warningScreen.
    public GameObject warningScreen;

    //Represents the game that has currently been selected.
    int selectedgame;

    /** Selected game is set to -1 is none have been chosen. The savescreen is
     deactivated alongside the warning screen.
    */
    void Start()
    {
        selectedgame = -1;
        deactivateScreen();
    }

    /** Activates the save screen, deactivates the warning screen.*/
    public void activateScreen() {
        saveScreen.SetActive(true);
        deactvateWarning();
    }

    /** Deactivates the save screen, deactivates the warning screen.*/

    public void deactivateScreen() {
        saveScreen.SetActive(false);
        deactvateWarning();
    }

    /** Activates the warning screen.*/

    public void actvateWarning() {
        warningScreen.SetActive(true);
    }

    /** Deactivates the warning screen, sets currently selected game to -1.*/

    public void deactvateWarning()
    {
        warningScreen.SetActive(false);
        selectedgame = -1;
    }

    /** Changes the currently selected game if the number is valid.*/

    public void changeGame(int num) {
        if (num != -1 && num < GameEnvironment.MAXIMUM_GAMES) {
            selectedgame = num;
            actvateWarning();
        }
    }

    /** Starts the currently selected game. */

    public void startGame() {
        if (selectedgame != -1) {
            MusicController.StopMusic();
            GameEnvironment.StartGame(selectedgame);
        }
    }
}
