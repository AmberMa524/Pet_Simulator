using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetPersonality : MonoBehaviour
{
    /** Controls the creation, generation and management of the pet's personality through
     the setting and getting of its' various traits. Traits are contained in the form of a
    list, which can be called.*/

    /** Contains a list of traits belonging to the pet, which cannot be altered or manipulated
     after being generated. */

    public List<Trait> traitList;

    /** Collects all of the traits from the pet and
     puts them into the trait list.*/

    /** Initialize trait list to match the one of the game's. */

    void Start()
    {
        traitList = GameEnvironment.currentGame.currentTraitList;
    }

    /** Initializes all of the traits in the trait list.*/
    
    public void initializer()
    {
        traitList = GameEnvironment.currentGame.currentTraitList;
    }

    /** Returns the list of traits.
     @return traitList*/

    public List<Trait> getTraitList()
    {
        return traitList;
    }

    /** Gets a trait based on a name. */

    public Trait getTrait(string name)
    {
        return traitList.Find(x => x.getType() == name);
    }

    /** Add trait to the trait list.
     @param getTrait
    */

    public void addTrait(Trait getTrait) {
        traitList.Add(getTrait);
    }
}
