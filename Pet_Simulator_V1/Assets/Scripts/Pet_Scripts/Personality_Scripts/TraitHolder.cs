using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitHolder : MonoBehaviour
{
    /** Represents a particular trait (academic, taste, etc.), which can contain a series of
      sub-preferences. When a sub-trait is included in the trait list, it will automatically
     be set with the trait's type.*/

    //The level of each sub trait will be a number between 0-99
    //If it is between 0-49, the pet will dislike it.
    //If it is between 50-99, the pet will like it.
    //The sub trait contains the highest score, that will be the
    //pet's personal favourite subtrait.
    public const int PREFERENCE_RANGE = 100;

    //The type of the trait, this determines the type of the trait
    //and affects how interactions will affect the pet.
    public string type;

    public Trait mainTrait;

    //Represents the list of subtraits contained inside the pet.
    public List<SubTrait> subTraitList;

    //public List<string> nameList;

    //public List<int> valueList;

    /** Gets all of the subtrait objects in the trait object,
     and places them in the subTraitList. Once that is done, the
    preference types of each subtrait will be converted to the type
    of the trait. Then, each trait will randomly generate a level for
    each sub trait.
    */

    void Start()
    {
        mainTrait = new Trait();
        mainTrait.type = type;
        subTraitList = new List<SubTrait>();
        foreach (Transform child in this.transform)
        {
            if (child.tag == "SubTrait")
            {
                SubTrait newSubtrait = new SubTrait(child.GetComponent<SubTraitHolder>().subTraitName, child.GetComponent<SubTraitHolder>().subTraitValue);
                newSubtrait.setType(type);
                subTraitList.Add(newSubtrait);
                //nameList.Add(child.GetComponent<SubTraitHolder>().subTraitName);
                //valueList.Add(child.GetComponent<SubTraitHolder>().subTraitValue);
            }
        }
        mainTrait.subTraitList = subTraitList;
    }

    public Trait getTrait() {
        return mainTrait;
    }
}
