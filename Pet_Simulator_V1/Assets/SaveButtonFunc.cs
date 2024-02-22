using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButtonFunc : MonoBehaviour
{
    public void SaveGame() {
        //Play Sound
        AudioController.gameSounds[2].Play();
        GameEnvironment.saveGame();
    }
}
