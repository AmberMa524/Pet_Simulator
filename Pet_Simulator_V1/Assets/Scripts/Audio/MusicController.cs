using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    /** Code that manages all in-game music. */

    /** 
     * Sources for code.
     * 
     * Maintaining data persistance between scenes was done using this resource:
        https://learn.unity.com/tutorial/implement-data-persistence-between-scenes#

        The use of multiple audio sources in code was done using this resource:
        https://answers.unity.com/questions/1320031/having-multiple-audio-sources-in-a-single-object.html
    */

    public const int MAX_VOLUME = 50;

    //The music controller instance.
    public static MusicController Instance;

    //An array of music included in the game.
    public static AudioSource[] gameSounds;

    //Represents the current music.
    public static int currentSound;

    //Represents whether or not the music is playing.
    public static bool isPlaying;

    //Represents the volume control for the music.
    public static int volume;

    /** Creates the first and only instance of the music controller.
     Sets volume to default value.*/

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        gameSounds = gameObject.GetComponents<AudioSource>();
        currentSound = 0;
        isPlaying = false;
        volume = MAX_VOLUME;
        DontDestroyOnLoad(gameObject);
    }

    /** Updates the music so that the volume is appropriate.*/

    void Update() {
        if (gameSounds != null)
        {
            gameSounds[currentSound].volume = volume * 0.001f;
        }
    }

    public static void changeVolume(int volumeAmt) {
        volume = volumeAmt;
    }

    /** Starts the in-game music. */

    public static void StartMusic()
    {
        if (gameSounds != null) 
        {
            isPlaying = true;
            gameSounds[currentSound].Play();
        }
    }

    /** Stops the in-game music. */

    public static void StopMusic()
    {
        if (gameSounds != null)
        {
            isPlaying = false;
            gameSounds[currentSound].Stop();
        }
    }

    /** Pauses the in-game music. */

    public static void PauseMusic()
    {
        if (gameSounds != null)
        {
            isPlaying = false;
            gameSounds[currentSound].Pause();
        }
    }

    /** Starts the in-game music. */

    public static void nextSong() {
        if (gameSounds != null)
        {
            if (isPlaying)
            {
                gameSounds[currentSound].Stop();
            }

            currentSound++;

            if (currentSound < 0)
            {
                currentSound = gameSounds.Length - 1;
            }
            else if (currentSound >= gameSounds.Length)
            {
                currentSound = 0;
            }
            if (isPlaying)
            {
                gameSounds[currentSound].Play();
            }
        }
    }

    /** Changes the in-game music. */

    public static void changeSong(int newVal)
    {
        if (gameSounds != null)
        {
            if (isPlaying)
            {
                gameSounds[currentSound].Stop();
            }

            currentSound = newVal;

            if (isPlaying)
            {
                gameSounds[currentSound].Play();
            }
        }
    }
}
