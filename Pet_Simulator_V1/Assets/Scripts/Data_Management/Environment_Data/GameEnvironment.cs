using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Manages in-game data such as time, date, and pet data.
 The data can be newly created, or loaded from a pre-existing game.
 The game environment manager is a static class, which comes into use when the game
 starts. The in-game clock only runs when the game is being played.
*/

public class GameEnvironment : MonoBehaviour
{
    //UNCOMMENT WHEN GAME IS FINALIZED:
    public const string HOME_SCENE = "Home";

    //Singular instance of game environment.
    public static GameEnvironment Instance;

    //Represents the time and date of the player's game.
    private static GameTime inGameTime;

    //Location (The area in the map where the player last left off).
    public static string location;

    //Determines the color of the text.
    public static Color textColor;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //Time manager is instantiated
        inGameTime = new GameTime();
        //The clock is stopped by default at the start.
        StopClock();
        //Prevents the game environment manager from being destroyed upon being loaded.
        DontDestroyOnLoad(gameObject);
    }

    /** Sets up the starter game data if the game is new.*/

    public static void NewGame() {
        //When a new game starts, the time and date is switched back to default settings.
        inGameTime.resetTime();
        //The location defaults to the home scene.
        //Uncomment When Finalized
        location = HOME_SCENE;
        //Text color is black by default.
        textColor = Color.black;
        //Remove when finalized.
        //location = "";
    }

    // FixedUpdate is called once per frame and updates the time accordingly.
    void FixedUpdate()
    {
        inGameTime.UpdateTime();
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
}
