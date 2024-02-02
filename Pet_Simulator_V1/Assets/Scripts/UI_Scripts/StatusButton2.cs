using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusButton2 : MonoBehaviour
{
    public GameObject statusButtons;
    public GameObject petStatus;
    public GameObject gameStatus;
    //public GameObject backButt;

    public void activateStatus()
    {
        statusButtons.SetActive(true);
        deactivatePet();
        deactivateGame();
    }

    public void deactivateStatus()
    {
        statusButtons.SetActive(false);
    }

    public void activatePet()
    {
        petStatus.SetActive(true);
        deactivateStatus();
        deactivateGame();
    }

    public void deactivatePet()
    {
        petStatus.SetActive(false);
    }

    public void activateGame()
    {
        gameStatus.SetActive(true);
        deactivatePet();
        deactivateStatus();
    }

    public void deactivateGame()
    {
        gameStatus.SetActive(false);
        //backButt.SetActive(false);
    }

    public void deactivateAll() {
        deactivatePet();
        deactivateStatus();
        deactivateGame();
    }
}
