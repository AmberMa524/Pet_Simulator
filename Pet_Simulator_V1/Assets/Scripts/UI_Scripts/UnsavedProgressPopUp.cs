using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UnsavedProgressPopUp : MonoBehaviour
{
    /**This script is for the window that pops up when the player selects
     the return to title option on the settings screen.
    */

    //Represents the pop up window that asks if the player is sure they want to quit.
    public GameObject popup_window;

    //Represents the title scene that the player will return to.
    public string title_scene;

    /** Window is deactivated at the start until the return to title button is clicked.*/
    void Start()
    {
        deactivateWindow();
    }

    /** Activates the pop up window. */

    public void activateWindow() {
        popup_window.SetActive(true);
    }

    /** Deactivates the pop up window. */

    public void deactivateWindow() {
        popup_window.SetActive(false);
    }

    /** Returns the player to title screen. */

    public void returnToTitle() {
        SceneManager.LoadScene(title_scene);
    }
}
