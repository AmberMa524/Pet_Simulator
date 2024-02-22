using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSlotData : MonoBehaviour
{
    public TMP_Text titletext;

    public GameObject gameWindow;

    public int currentSelectedGame;

    // Start is called before the first frame update
    void Start()
    {
        exitGame();
    }

    public void openGame(int num) {
        currentSelectedGame = num;
        gameWindow.SetActive(true);
        int gameNum = currentSelectedGame + 1;
        titletext.text = "Game #" + gameNum;
    }

    public void startGame() {
        if (currentSelectedGame != -1) {
            GameEnvironment.StartGame(currentSelectedGame);
        }
    }

    public void deleteGame() {
        if (currentSelectedGame != -1)
        {
            GameEnvironment.deleteGame(currentSelectedGame);
        }
        exitGame();
    }

    public void exitGame(){
        currentSelectedGame = -1;
        gameWindow.SetActive(false);
    }
}
