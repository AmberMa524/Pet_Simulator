using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusButton : MonoBehaviour
{

    /** Activates the status buttons on the in-game UI.*/

    //Represents the status buttons.
    public GameObject statusButtons;

    //Represents the window with the pet status data.
    public GameObject petStatus;

    //Represents the window with the game status data.
    public GameObject gameStatus;

    /** The status buttons are activated at the start. */
    void Start()
    {
        activateStatus();
    }

    /** Activates the status buttons. Deactivates the game and pet status windows.*/

    public void activateStatus() {
        statusButtons.SetActive(true);
        deactivatePet();
        deactivateGame();
    }

    /** Deactivates the status buttons.*/

    public void deactivateStatus()
    {
        statusButtons.SetActive(false);
    }

    /** Activates the pet status window. Deactivates the status buttons and game status window.*/

    public void activatePet()
    {
        petStatus.SetActive(true);
        deactivateStatus();
        deactivateGame();
    }

    /** Deactivates the pet status window.*/

    public void deactivatePet()
    {
        petStatus.SetActive(false);
    }

    /** Activates the game status window. Deactivates the status buttons and pet status window.*/

    public void activateGame()
    {
        gameStatus.SetActive(true);
        deactivatePet();
        deactivateStatus();
    }

    /** Deactivates the game status window.*/

    public void deactivateGame()
    {
        gameStatus.SetActive(false);
    }
}
