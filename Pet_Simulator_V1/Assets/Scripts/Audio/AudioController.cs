using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    /** 
     * A script that controls in-game sound effects.
     * 
     * Sources for code.
     * 
     * Maintaining data persistance between scenes was done using this resource:
        https://learn.unity.com/tutorial/implement-data-persistence-between-scenes#

        The use of multiple audio sources in code was done using this resource:
        https://answers.unity.com/questions/1320031/having-multiple-audio-sources-in-a-single-object.html
    */

    //The instance of this audio controller.
    public static AudioController Instance;

    //An array of in-game sounds.
    public static AudioSource[] gameSounds;

    /** Sets up the audio controller by creating the instance.
     All of the in-game sounds will be the audio source files associated
     with it.*/

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        gameSounds = gameObject.GetComponents<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    /** Takes in an integer and plays the sound effect that is associated
     with that number. If no sound is associated with that number, nothing
     will play.
     @param soundInt
    */

    public static void PlaySFX(int soundInt) {
        if (gameSounds.Length > 0) {
            if (soundInt < 0 || soundInt > gameSounds.Length - 1)
            {
                Debug.Log("sound Played");
                gameSounds[soundInt].Play();
            }
        }
    }
}
