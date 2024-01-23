using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    /** Script that controls the changing of scenes.
     This will be applied to objects in the game to allow scenes
    to change.
    */

    /** Changes scene to the designated scene.
     @param name */
    public void ChangeScene(string name) {
        SceneManager.LoadScene(name);
    }
}
