using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tutorial
{
    /** An object that contains sprites that represent a tutorial for the player. 
     The player should be able to flip through these sprites in the tutorial mode.*/

    //The name of the tutorial.
    [SerializeField] private string name;

    //An array of sprites for the tutorial.
    [SerializeField] private List<Sprite> screens;

    /** Tutorial constructor, which creates the tutorial based on
     * a name and list of sprites/screens. */
    public Tutorial(string tutName, List<Sprite> tutScreens) {
        name = tutName;
        screens = tutScreens;
    }

    /** Gets the name of the tutorial. */

    public string getName() {
        return name;
    }

    /** Gets the list of sprites for the tutorial. */

    public List<Sprite> getScreens()
    {
        return screens;
    }

}
