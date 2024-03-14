using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowRotation : MonoBehaviour
{
    /** Rotates the text on the item description window to ensure that the text is still visible.*/

    //The amount at which the window will rotate depending on the x value of the item's position on the y-axis.
    public const float ROTATION_FACTOR_Y = 1.8f;

    //The amount at which the window will rotate depending on the x value of the item's position on the x-axis.
    public const float ROTATION_FACTOR_X = 0.9f;

    //The item that the window belongs to.
    public GameObject testItem;

    /** Alters the rotation of the window based on the x position of the item. */
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(testItem.transform.position.y*(ROTATION_FACTOR_X), testItem.transform.position.x * ROTATION_FACTOR_Y, 0);
    }
}
