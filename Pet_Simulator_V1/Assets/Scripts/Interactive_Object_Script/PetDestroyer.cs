using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetDestroyer : MonoBehaviour
{
    /** Allows the trash can to animate itself.*/
    private Animator animator;
    //Gets the GFX object that controls the sprite animations.
    public GameObject GFXController;

    /** Sets trash can to default animation.*/
    void Start()
    {
        animator = GFXController.GetComponent<Animator>();
        animator.SetInteger("Animation_Part", 0);
    }

    /** Trash can opens when the player's mouse hovers over.*/

    void OnMouseOver()
    {
        animator.SetInteger("Animation_Part", 1);
    }

    /** Responds to when the player stops hovering.*/

    void OnMouseExit()
    {
        animator.SetInteger("Animation_Part", 0);
    }
}
