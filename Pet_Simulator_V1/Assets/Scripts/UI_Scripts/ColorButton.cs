using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    /** Script assigned to all color buttons, which takes the color of the button and applies it to
     the in-game text. */

    //Represents the color of the button.
    private Color thisColor;

    //The color value changes to the color of the button.
    void Start()
    {
        thisColor = gameObject.GetComponent<Image>().color;
    }

    /** Changes the game environment's text color to that of the button's color. */

    public void changeTextColor() {
        GameEnvironment.changeColor(thisColor);
    }
}
