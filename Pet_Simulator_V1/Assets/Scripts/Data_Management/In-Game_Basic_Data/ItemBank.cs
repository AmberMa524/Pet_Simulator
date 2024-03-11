using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Since this data will need to be saved and loaded,
 this data is serializable.*/

[System.Serializable]
public class ItemBank : MonoBehaviour
{

    /**This is a bank of in-game items and data. This will be used to add new traits, item sprites, etc,
     which can be grabbed from by the pet.*/

    [SerializeField] public static ItemBank Instance;

    [SerializeField] public static List<Trait> traitList;

    [SerializeField] public static List<Sprite> spriteList;

    [SerializeField] public static List<State> stateList;

    [SerializeField] public List<GameObject> traitExternalList;

    [SerializeField] public List<Sprite> spriteExternalList;

    [SerializeField] public List<GameObject> stateExternalList;

    [SerializeField] private bool initialized;

    /**Initializes itself.*/

    void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        initialized = false;
        DontDestroyOnLoad(gameObject);
    }

    /** If the item bank has not initialized, grab all of the
     *traits, subtraits, states and the sprite list to establish
     *the item bank.
     *
     *NOTE:: This must be established first before the game data loads. 
    */

    void Update() {
        if (!initialized) {
            traitList = new List<Trait>();
            foreach (GameObject go in traitExternalList)
            {
                Trait newTrait = new Trait();
                newTrait.type = go.GetComponent<TraitHolder>().type;
                newTrait.subTraitList = new List<SubTrait>();
                foreach (SubTrait st in go.GetComponent<TraitHolder>().subTraitList) {
                    SubTrait newSubtrait = new SubTrait(st.getName(), st.getValue());
                    newTrait.subTraitList.Add(newSubtrait);
                }
                traitList.Add(newTrait);
            }
            stateList = new List<State>();
            foreach (GameObject go in stateExternalList)
            {
                State objectState = go.GetComponent<StateHolder>().stateItem;
                State newState = new State(objectState.getType(), objectState.getName(), objectState.getSpriteNumber(), objectState.interval);
                stateList.Add(newState);
            }
            spriteList = spriteExternalList;
            initialized = true;
            GameEnvironment.dataLoadFinished = true;
        }
    }
}
