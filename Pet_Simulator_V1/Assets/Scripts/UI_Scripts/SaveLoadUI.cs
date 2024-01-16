using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadUI : MonoBehaviour
{
    public GameObject saveScreen;

    // Start is called before the first frame update
    void Start()
    {
        deactivateScreen();
    }

    public void activateScreen() {
        saveScreen.SetActive(true);
    }

    public void deactivateScreen() {
        saveScreen.SetActive(false);
    }
}
