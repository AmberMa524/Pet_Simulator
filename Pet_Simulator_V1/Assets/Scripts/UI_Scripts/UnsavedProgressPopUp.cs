using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UnsavedProgressPopUp : MonoBehaviour
{
    public GameObject popup_window;

    public string title_scene;
    // Start is called before the first frame update
    void Start()
    {
        deactivateWindow();
    }

    public void activateWindow() {
        popup_window.SetActive(true);
    }

    public void deactivateWindow() {
        popup_window.SetActive(false);
    }

    public void returnToTitle() {
        SceneManager.LoadScene(title_scene);
    }
}
