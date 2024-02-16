using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorText : MonoBehaviour
{
    /** A script that takes the color from the game environment and applies it to any given text object.*/
    void Update()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().color = GameEnvironment.textColor;
    }
}
