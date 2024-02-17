using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    /** A script that maintains all data for a single game. This data can be written to and read from a file. This data can
     * be loaded and saved within the game.
     */

    //Defines the current location of the player.
    public string currentLocation;

    //Defines the current time and date in the game.
    public GameTime currentTimeDate;

    //Defines the current text color in the game.
    public Color currentColor;

    //Defines all of the unique interactions the pet has done.
    public InteractionCatalogue currentInteractionList;

    //Defines the list of states the pet has as well as their data.
    public List<State> currentStateList;

    //Defines the current preferences of the pet.
    public PreferenceManager currentPreferenceManager;

    //Defines the current learned behaviors of the pet.
    public LearnedBehaviourManager currentLearnedBehaviourManager;

    //Defines the current trait list of the pet.
    public List<Trait> currentTraitList;

}
