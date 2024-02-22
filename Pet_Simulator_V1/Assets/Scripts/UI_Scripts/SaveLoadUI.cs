using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadUI : MonoBehaviour
{
    public GameObject saveScreen;
    public GameObject warningScreen;

    int selectedgame;

    // Start is called before the first frame update
    void Start()
    {
        selectedgame = -1;
        deactivateScreen();
    }

    public void activateScreen() {
        saveScreen.SetActive(true);
        deactvateWarning();
    }

    public void deactivateScreen() {
        saveScreen.SetActive(false);
        deactvateWarning();
    }

    public void actvateWarning() {
        warningScreen.SetActive(true);
    }

    public void deactvateWarning()
    {
        warningScreen.SetActive(false);
        selectedgame = -1;
    }

    public void changeGame(int num) {
        if (num != -1 && num < GameEnvironment.MAXIMUM_GAMES) {
            selectedgame = num;
            actvateWarning();
        }
    }

    public void startGame() {
        if (selectedgame != -1) {
            MusicController.StopMusic();
            GameEnvironment.StartGame(selectedgame);
        }
    }
}
