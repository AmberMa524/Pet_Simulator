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
    [SerializeField] public GameTime currentTimeDate;

    //Defines the current text color in the game.
    [SerializeField] public Color currentColor;

    //Defines all of the unique interactions the pet has done.
    [SerializeField] public InteractionCatalogue currentInteractionList;

    //Defines the list of states the pet has as well as their data.
    [SerializeField] public List<State> currentStateList;

    //Defines the current preferences of the pet.
    [SerializeField] public PreferenceManager currentPreferenceManager;

    //Defines the current learned behaviors of the pet.
    [SerializeField] public LearnedBehaviourManager currentLearnedBehaviourManager;

    //Defines the current trait list of the pet.
    [SerializeField] public List<Trait> currentTraitList;

    [SerializeField] public PetMemories currentMemory;

    //Defines if the slot is empty;
    public bool isEmpty;

    public GameData() {
        isEmpty = true;
        currentTraitList = new List<Trait>();
        foreach (Trait tr in ItemBank.traitList)
        {
             tr.randomTraitGeneration();
             tr.setUpPreferenceTypes();
             currentTraitList.Add(tr);
        }
        currentStateList = new List<State>();
         foreach (State st in ItemBank.stateList)
        {
            State newState = new State(st.getName(), st.getType(), st.getSpriteNumber());
            newState.resetState();
            currentStateList.Add(newState);
         }
        currentMemory = new PetMemories();
        currentLearnedBehaviourManager = new LearnedBehaviourManager();
        currentPreferenceManager = new PreferenceManager();
        currentInteractionList = new InteractionCatalogue();
        currentTimeDate = new GameTime();
        currentColor = Color.black;
        }

    public GameData ShallowCopy()
    {
        return (GameData)this.MemberwiseClone();
    }
}

/** Designed to wrap a list of games (maximum 3) for transport as a JSON
 file.*/

[System.Serializable]
public class GameDataWrapper
{
    public List<GameData> _GameData = new List<GameData>();
}
