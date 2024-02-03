using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    /** 
     * Sources for code.
     * 
     * Maintaining data persistance between scenes was done using this resource:
        https://learn.unity.com/tutorial/implement-data-persistence-between-scenes#

        The use of multiple audio sources in code was done using this resource:
        https://answers.unity.com/questions/1320031/having-multiple-audio-sources-in-a-single-object.html
    */

    public static AudioController Instance;
    public static AudioSource[] gameSounds;

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
        DontDestroyOnLoad(gameObject);
    }

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
