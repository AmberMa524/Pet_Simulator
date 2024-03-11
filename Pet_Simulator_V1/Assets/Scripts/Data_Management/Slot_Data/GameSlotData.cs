using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSlotData : MonoBehaviour
{
    /** Controls the UI tools used to play and delete selected
     games in a game load/save menu.*/

    //The title of the game in the window.
    public TMP_Text titletext;

    //The game window, which contains the play button and delete button.
    public GameObject gameWindow;

    //Represents the current game selected.
    public int currentSelectedGame;

    //The window should be closed at the start.
    void Start()
    {
        exitGame();
    }

    /**Opens the window to the given game data, whose ID was given in the num param.
     * @param num*/

    public void openGame(int num) {
        currentSelectedGame = num;
        gameWindow.SetActive(true);
        int gameNum = currentSelectedGame + 1;
        titletext.text = "Game #" + gameNum;
    }

    /**Starts the game that has been selected if valid.*/

    public void startGame() {
        if (currentSelectedGame != -1) {
            GameEnvironment.StartGame(currentSelectedGame);
        }
    }

    /** Deletes the game that has been selected if valid. */

    public void deleteGame() {
        if (currentSelectedGame != -1)
        {
            GameEnvironment.deleteGame(currentSelectedGame);
        }
        exitGame();
    }

    /** Closes the game window. */

    public void exitGame(){
        currentSelectedGame = -1;
        gameWindow.SetActive(false);
    }
}
