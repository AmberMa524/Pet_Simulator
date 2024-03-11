using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Since this data will need to be saved and loaded,
 this data is serializable.*/

[System.Serializable]
public class Trait
{
    /** Represents a particular trait (academic, taste, etc.), which can contain a series of
     sub-preferences. When a sub-trait is included in the trait list, it will automatically
    be set with the trait's type.*/

    //The level of each sub trait will be a number between 0-99
    //The sub trait contains the highest score, that will be the
    //pet's personal favourite subtrait.
    public const int PREFERENCE_RANGE = 100;
    
    //The type of the trait, this determines the type of the trait
    //and affects how interactions will affect the pet.
    public string type;

    //Represents the list of subtraits contained inside the pet.
    public List<SubTrait> subTraitList;

    /** Gets all of the subtrait objects in the trait object,
     and places them in the subTraitList. Once that is done, the
    preference types of each subtrait will be converted to the type
    of the trait. Then, each trait will randomly generate a level for
    each sub trait.
    */

    public Trait() {
        subTraitList = new List<SubTrait>();
        setUpPreferenceTypes();
        randomTraitGeneration();
    }

    /** 
     * Generates the values of each subtrait, thus determining
     how much the pet favours each subtrait. The generation of 
     trait values will be random to ensure a different experience each
    time.
    */

    public void randomTraitGeneration() {
        for (int i = 0; i < subTraitList.Count; i++) {
            int randomNumber = Random.Range(0, PREFERENCE_RANGE);
            subTraitList[i].setValue(randomNumber);
        }
    }

    /** Dynamically applies the trait's type to its'
     sub-traits to control how the trait interacts with
    interactions from the player.*/

    public void setUpPreferenceTypes()
    {
        if (subTraitList.Count != 0) {
            for (int i = 0; i < subTraitList.Count; i++) {
                subTraitList[i].setType(type);
            }
        }
    }

    /** 
     * Gets the type of the trait. 
     * @return type
    */

    public string getType() {
        return type;
    }

    /** Gets a trait based on a name. */

    public SubTrait getSubTrait(string name)
    {
        return subTraitList.Find(x => x.getName() == name);
    }

    /** Returns the subtrait list from the trait. */

    public List<SubTrait> getSubTraitList() {
        return subTraitList;
    }
}
