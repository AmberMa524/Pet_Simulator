using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    /** Controls the Exit Game Button, which allows the player to exit the application. */

    //Represents the warning Popup Window.
    public GameObject popupWindow;

    void Start()
    {
        deactivatePopUp();
    }

    /** Activates the popup. */

    public void activatePopUp() {
        popupWindow.SetActive(true);
    }

    /** Deactivates the popup. */

    public void deactivatePopUp()
    {
        popupWindow.SetActive(false);
    }

    /** Exits the application. */

    public void exitGame() {
        Application.Quit();
    }
}
