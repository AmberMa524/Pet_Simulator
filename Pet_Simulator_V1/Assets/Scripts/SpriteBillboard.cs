using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{

    /** 
     * This script is designed to ensure that the sprites are visible when the camera angle changes.
     * 
     * This script came from:
     * https://www.youtube.com/watch?v=UcYfEfJW_mk
     */

    [SerializeField] bool freezeXZAxis = true;

    private void Update() {

        if (freezeXZAxis)
        {
            transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
        }
        else {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}
