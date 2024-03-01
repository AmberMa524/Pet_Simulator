using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoad : MonoBehaviour
{
    /** The clock starts as soon as the room loads again.
     All the states reawaken, and the pet's physics kick in again.
    The location data is loaded to the environment for use later.
    */

    //Provides the name of the pet's current location.
    public string locationName;

    //Provides the spawn point of the pet.
    public Vector3 spawnPoint;

    //Provides the song to be played in this room.
    public int roomSong;

    //Provides the maximum z value the pet can walk across.
    public int maxBound;

    //Provides the minimum z value the pet can walk across.
    public int minBound;

    //Determines if the room has fully loaded (along with the pet).
    public bool hasLoaded;

    /** 
     The in-game clock should start up again, as well as the music.
      If the room has changed between scenes, then the information on
      how far the pet can move in that room should change.
      The pet should be able to use gravity again.
     */

    void Start()
    {
        GameEnvironment.StartClock();
        MusicController.PauseMusic();
        if (locationName != GameEnvironment.getLocation()) {
            MusicController.StopMusic();
            GameObject.FindGameObjectWithTag("Pet").transform.position = spawnPoint;
            GameObject.FindGameObjectWithTag("Pet").GetComponent<PetMovement>().changeMaxBound(maxBound);
            GameObject.FindGameObjectWithTag("Pet").GetComponent<PetMovement>().changeMinBound(minBound);
        }
        GameEnvironment.changeLocation(locationName);
        GameObject.FindGameObjectWithTag("Pet").GetComponent<Rigidbody>().useGravity = true;
        MusicController.changeSong(roomSong);
        MusicController.StartMusic();
        hasLoaded = false;
    }

    /** If the pet has loaded, the room will unpause their states.*/

    void Update() {
        if (!hasLoaded) {
            GameObject.FindGameObjectWithTag("Pet").GetComponent<PetState>().unpauseStates();
            hasLoaded = true;
        }
    }

}
