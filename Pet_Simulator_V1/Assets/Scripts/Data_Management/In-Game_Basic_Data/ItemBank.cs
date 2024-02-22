using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
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

    void Update() {
        if (!initialized) {
            traitList = new List<Trait>();
            foreach (GameObject go in traitExternalList)
            {
                Trait newTrait = new Trait();
                newTrait.type = go.GetComponent<TraitHolder>().type;
                newTrait.subTraitList = new List<SubTrait>();
                //Debug.Log(go.GetComponent<TraitHolder>().subTraitList.Count);
                foreach (SubTrait st in go.GetComponent<TraitHolder>().subTraitList) {
                    //Debug.Log(st.getName());
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
