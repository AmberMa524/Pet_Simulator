using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction
{
    /** Represents an interaction in the game, which will be posessed by every interactable
     * object. This interaction will be passed into the pet's calculation functionality from
     * the interactable object. Interactions will contain a value called a type, which determines
     * what need the action will satisfy for the pet. The subtype indicates what kind of taste
     * or sensibility it appeals to. The pet's tastes and sensibilities are determined by their
     * subtraits. Depending on the pet's tastes and how frequently the pet has interacted with
     * this interaction (determined through its' memories), the pet may prefer this interaction
     * and this preference would be reflected in the pet's status.
     */

    //Identifies the interaction in the game.
    public int interactionID;

    //Identifies the type of interaction in the game.
    public string interactionType;

    //Identifies the interaction subtype in the game.
    public string interactionSubType;

    //Provides a description of the interaction.
    public string interactionName;

    //Provides the index of the sprite associated with the interaction.
    public int interactionSpriteIndex;

    /** Interactive constructor. 
     @param id
     @param type
     @param name
     @param sprite
    */

    public Interaction(int id, string type, string name, string sub, int sprite)
    {
        setID(id);
        setType(type);
        setName(name);
        setSub(sub);
        setSprite(sprite);
    }

    /** Gets the id of the interaction. 
     @return interactionID
    */

    public int getID()
    {
        return interactionID;
    }

    /** Gets the type of the interaction.
     @return interactionType
    */

    public string getType()
    {
        return interactionType;
    }

    /** Gets the name of the interaction.
     @return interactionName
    */

    public string getName()
    {
        return interactionName;
    }

    /** Gets the subtype of the interaction.
         @return interactionSubType
        */

    public string getSub()
    {
        return interactionSubType;
    }

    /** Gets the sprite of the interaction.
     @return interactionSpriteIndex
    */

    public int getSprite()
    {
        return interactionSpriteIndex;
    }

    /** Sets the ID of the interaction.
     @param id*/

    public void setID(int id)
    {
        interactionID = id;
    }

    /** Sets the type of the interaction.
    @param type*/

    public void setType(string type)
    {
        interactionType = type;
    }

    /** Sets the name of the interaction.
    @param name*/

    public void setName(string name)
    {
        interactionName = name;
    }

    /** Sets the sub type of the interaction.
    @param sub*/

    public void setSub(string sub)
    {
        interactionSubType = sub;
    }

    /** Sets the sprite index. of the interaction.
    @param sprite
    */

    public void setSprite(int sprite)
    {
        interactionSpriteIndex = sprite;
    }
}
