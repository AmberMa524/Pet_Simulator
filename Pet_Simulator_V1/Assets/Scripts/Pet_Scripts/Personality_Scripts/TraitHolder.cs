using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitHolder : MonoBehaviour
{
    /**A gameobject that contains the data of a trait, which will
     be passed down to the item bank. This is a measure to help
     modularize the process of adding trait objects for any future changes
    that may come. The trait object should contain children to represent subtraits
    for this trait. The subtraits will be included in the item bank as well.
    */

    /** String value that must be applied to the trait, which represents what
     type the trait is.*/
    public string type;

    //This represents the trait object created by this trait holder.
    public Trait mainTrait;

    //Represents the list of subtraits contained inside the pet.
    public List<SubTrait> subTraitList;

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
            }
        }
        mainTrait.subTraitList = subTraitList;
    }

    /** Returns the trait object created in this trait holder.
     @return mainTrait*/

    public Trait getTrait() {
        return mainTrait;
    }
}
