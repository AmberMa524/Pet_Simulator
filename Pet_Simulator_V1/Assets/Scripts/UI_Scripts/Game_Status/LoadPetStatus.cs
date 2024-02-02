using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPetStatus : MonoBehaviour
{
    //Represents the maximum number of rows each page can have.
    public const int MAX_ROWS = 5;

    /** This script is designed to dynamically display the pet's existing personality
     and preferences in a clear, easy to understand way. */

    //A gameobject that holds all the pet's personality information.
    public TMP_Text personalityText;
    public TMP_Text personalityTitle;
    private int personalityIndex;
    private List<Trait> traitList;
    private Button nextTrait;

    //A gameobject that holds all of the pet's preferential information.
    public TMP_Text favouritesText;
    public TMP_Text favouritesTitle;
    private int favouriteIndex;
    private List<Preference> preferenceList;
    private Button nextPreference;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
