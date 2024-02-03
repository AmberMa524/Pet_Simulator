using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    /** 
     * Sources for code.
     * 
     * Maintaining data persistance between scenes was done using this resource:
        https://learn.unity.com/tutorial/implement-data-persistence-between-scenes#

        The use of multiple audio sources in code was done using this resource:
        https://answers.unity.com/questions/1320031/having-multiple-audio-sources-in-a-single-object.html
    */

    public static MusicController Instance;
    public static AudioSource[] gameSounds;
    public static int currentSound;
    public static bool isPlaying;
    public static int volume;

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
        volume = 50;
        DontDestroyOnLoad(gameObject);
    }

    void Update() {
        gameSounds[currentSound].volume = volume*0.001f;
    }

    public static void changeVolume(int volumeAmt) {
        volume = volumeAmt;
    }

    public static void StartMusic()
    {
        isPlaying = true;
        gameSounds[currentSound].Play();
    }

    public static void StopMusic()
    {
         isPlaying = false;
         gameSounds[currentSound].Stop();
    }

    public static void PauseMusic()
    {
         isPlaying = false;
         gameSounds[currentSound].Pause();
    }

    public static void nextSong() {
        if (isPlaying) {
            gameSounds[currentSound].Stop();
        }

        currentSound++;

        if (currentSound < 0)
        {
            currentSound = gameSounds.Length - 1;
        }
        else if (currentSound >= gameSounds.Length) {
            currentSound = 0;
        }
        if (isPlaying) {
            gameSounds[currentSound].Play();
        }
    }

    public static void changeSong(int newVal)
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
