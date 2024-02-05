using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtSpriteChange : MonoBehaviour
{

    /** 
     Referred to this page for reference:
    https://gamedevbeginner.com/how-to-change-a-sprite-from-a-script-in-unity-with-examples/

    This is a controller, which controls how the thought bubble sprite changes depending on what
    preference/learned behaviour is being brought up by the pet. Please note that the pet's state takes
    priority when it comes to what suggestion is being shown. If the pet is not in any state and merely remembers
    a learned behaviour, then learned behaviour will take priority.

    This class will need to be static so that it can be called from anywhere in the script (important for situations
    in which the behavioural scripts need to manipulate the thought sprite.
     */

    //Represents the sprite renderer of the sprite changer.
    public SpriteRenderer spriteRenderer;

    //An array of sprites in the sprite object.
    public List<Sprite> spriteArray;

    /** Creates the instance of the sprite changer, which grabs
     all the sprites in the thought elements object, then places them
    in the array.*/
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    /** Changes the current sprite of the thought bubble to whichever sprite
     is indexed at a particular place. Checks if the index is in bounds before
    setting the sprite.
    @param spriteIndex
    */

    public void ChangeSprite(int spriteIndex)
    {
        if (spriteIndex < spriteArray.Count && spriteIndex >= 0) {
            spriteRenderer.sprite = spriteArray[spriteIndex];
        }
    }
}
