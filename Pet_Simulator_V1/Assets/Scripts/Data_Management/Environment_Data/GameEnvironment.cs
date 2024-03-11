using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

/** 
 * Manages in-game data such as time, date, and pet data.
 The data can be newly created, or loaded from a pre-existing game.
 The game environment manager is a static class, which comes into use when the game
 starts. The in-game clock only runs when the game is being played.
*/

public class GameEnvironment : MonoBehaviour
{
    //Represents the maximum number of games in the game.
    public const int MAXIMUM_GAMES = 3;

    //Singular instance of game environment.
    public static GameEnvironment Instance;

    //Represents the time and date of the player's game.
    private static GameTime inGameTime;

    //Location (The area in the map where the player last left off).
    public static string location;

    //Determines the color of the text.
    public static Color textColor;

    //Determines the current game being run.
    public static GameData currentGame;

    //Determines the number of the current game
    public static int currentGameNum;

    //Gets the current game data used for the game.
    public static List<GameData> currentGameData;

    //Determines if the item bank is finished loading.
    public static bool dataLoadFinished;

    //Refers to the first in-game scene.
    public string homeScene;

    //The title of the game data file where all the data will be held.
    public string gameDataTitle;

    /** Initializes the basic information.
     Program waits until update function to 
    load the game data, as the basic utility data
    may not be initialized yet.*/

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //Prevents the game environment manager from being destroyed upon being loaded.
        currentGameNum = -1;
        dataLoadFinished = false;
        DontDestroyOnLoad(gameObject);
    }

    /** Sets up the starter game data if the game is new.*/

    public static void NewGame() {
        if (currentGame != null) {
            currentGame.currentLocation = Instance.homeScene;
            currentGame.currentTimeDate = new GameTime();
            currentGame.currentColor = Color.black;
            currentGame.currentInteractionList = new InteractionCatalogue();
            currentGame.currentPreferenceManager = new PreferenceManager();
            currentGame.currentLearnedBehaviourManager = new LearnedBehaviourManager();
            currentGame.isEmpty = false;
            currentGame.generatePersonality();
        }
    }

    /** Starts up a brand new game based on the game index specified in 
     * num. If the number is valid, then the game is loaded.
     @param num*/

    public static void StartGame(int num) {
        if (num >= 0 && num <= MAXIMUM_GAMES) {
            currentGameNum = num;
            currentGame = currentGameData[currentGameNum].ShallowCopy();
            if (currentGame.isEmpty) {
                NewGame();
            }
            location = currentGame.currentLocation;
            inGameTime = currentGame.currentTimeDate;
            textColor = currentGame.currentColor;
            if (GameObject.FindGameObjectWithTag("Pet") != null) {
                GameObject.FindGameObjectWithTag("Pet").GetComponent<PetPersonality>().initializer();
                GameObject.FindGameObjectWithTag("Pet").GetComponent<PetBehaviour>().initializer();
                GameObject.FindGameObjectWithTag("Pet").GetComponent<PetMain>().initializer();
                GameObject.FindGameObjectWithTag("Pet").GetComponent<PetState>().initializer();
            }
            SceneManager.LoadScene(location);
        }
    }

    /** If the data hasn't finished loading, it will be loaded.
     If the game time is not a null value, it will be updated.*/
    void FixedUpdate()
    {
        if (inGameTime != null) {
           inGameTime.UpdateTime();
        }
        if (dataLoadFinished) {
            loadGameDataFromFile();
            dataLoadFinished = false;
        }
    }

    /** Unpauses the in-game clock so that it may increment.*/

    public static void StartClock() {
        inGameTime.startTime();
    }

    /** Pauses the in-game clock, preventing it from incrementing.*/

    public static void StopClock() {
        inGameTime.pauseTime();
    }

    /** Returns the in game time manager.
     @return inGameTime
    */

    public static GameTime getGameTime() {
        return inGameTime;
    }

    /** When a game is terminated, the pet will be terminated from the scene.
     If the pet's data is not saved, it will be lost.
    */

    public static void terminateGame() {
        Destroy(GameObject.FindGameObjectWithTag("Pet"));
        currentGameNum = -1;
        Debug.Log("Terminated Game");
    }

    /** Changes the current location to a new location.
     @param newLoc*/

    public static void changeLocation(string newLoc) {
        location = newLoc;
    }

    /** Gets the current location of the game. */

    public static string getLocation() {
        return location;
    }

    /** Changes the current text color to a new color.
     @param newCol*/

    public static void changeColor(Color newCol)
    {
        textColor = newCol;
    }

    /** Gets the current color of the game. */

    public static Color getColor()
    {
        return textColor;
    }

    /** Loads game data from file. */

    public static void loadGameDataFromFile() {
        //Try to find the data.
        string data = "";
        try
        {
            data = System.IO.File.ReadAllText("./" + Instance.gameDataTitle + ".json");
        }
        catch (Exception e) {
            Debug.Log("Data not found");
            Debug.Log(e);
        }
        //If data is found, then add it to the current game data.
        if (data != "")
        {
            GameDataWrapper dataCollect = JsonUtility.FromJson<GameDataWrapper>(data);
            currentGameData = new List<GameData>();
            for (int i = 0; i < dataCollect._GameData.Count; i++) {
                currentGameData.Add(dataCollect._GameData[i]);
            }
        }
        else {
            //If data is not found, then add new game data and save it to the file.
            currentGameData = new List<GameData>();
            for (int i = 0; i < MAXIMUM_GAMES; i++) {
                currentGameData.Add(new GameData());
            }
            saveGame();
        }
    }

    /** Loads game data based on number 
     @param num 
    */

    public void loadGameData(int num) {
        if (num >= 0 && num < MAXIMUM_GAMES) {
            currentGame = currentGameData[num];
        }
    }

    /** Saves current game data to json file. */

    public static void saveGame() {
        //If a game is currently playing, save the game data for it.
        if (currentGameNum >= 0 && currentGameNum < MAXIMUM_GAMES) {
            currentGameData[currentGameNum].currentLocation = location;
            currentGameData[currentGameNum].currentTimeDate = inGameTime;
            currentGameData[currentGameNum].currentColor = textColor;
            currentGameData[currentGameNum].currentInteractionList = currentGame.currentInteractionList;
            currentGameData[currentGameNum].currentPreferenceManager = currentGame.currentPreferenceManager;
            currentGameData[currentGameNum].currentLearnedBehaviourManager = currentGame.currentLearnedBehaviourManager;
            currentGameData[currentGameNum].isEmpty = false;
        }
        //The data will be wrapped to prepare it for writing.
        GameDataWrapper dataWrap = new GameDataWrapper();
        //Game data list will be added to the data wrap.
        dataWrap._GameData = new List<GameData>();
        //Loop through all the current in-game data and save
        //all of the game data to the wrapper.
        foreach (GameData gd in currentGameData)
        {
            dataWrap._GameData.Add(gd);
        }
        //Convert the data wrapper to a string.
        string game = JsonUtility.ToJson(dataWrap);
        //Write the string to the file.
        System.IO.File.WriteAllText("./" + Instance.gameDataTitle + ".json", game);
        //Reload all of the data again to keep the data up to date.
        loadGameDataFromFile();
    }

    /** Deletes the game identified by int num. If the game
     number is out of bounds, it will not be accepted. If deletion
     occurs during the game, measures are taken to ensure that the
     data file deletes without deleting the current game they are playing.
    @param num
    */

    public static void deleteGame(int num) {
        //If the game number is valid, then delete that game.
        if (num >= 0 && num < MAXIMUM_GAMES) {
            bool duringGame = false;
            if (num == currentGameNum)
            {
                duringGame = true;
                currentGameNum = -1;
            }
            currentGameData[num] = new GameData();
            saveGame();
            if (duringGame) {
                currentGameNum = num;
            }
        }
    }
}
