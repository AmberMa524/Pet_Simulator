using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/** The game slots will be dynamically generated using the saved data in
 the game's files, which will be passed in upon being clicked.*/

public class GameSlot : MonoBehaviour
{
    //Game data to be passed on to the GameEnvironment load function.
    public bool empty;
    public string file_name;
    public string time_stamp;
    public string location;

    //Time Data
    public int hour;
    public int minute;
    public int second;

    //Date Data
    public int year;
    public int month;
    public int day;

    //Text objects.
    public TMP_Text fn_text;
    public TMP_Text ts_text;
    public TMP_Text lc_text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fn_text.text = file_name;
        ts_text.text = time_stamp;
        lc_text.text = location;
    }

    public void StartGame() {
            GameEnvironment.NewGame();
            SceneManager.LoadScene(GameEnvironment.HOME_SCENE);
    }
}
