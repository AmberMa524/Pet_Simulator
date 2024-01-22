using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMain : MonoBehaviour
{
    /** This is the pet's main controller, which will contain its memories,
     behaviours, and personality. The interactions and calculations will be
    performed through this script.*/

    //Animation Values
    //Manipulates animations for pet.
    private Animator animator;
    //Gets the GFX object that controls the sprite animations.
    public GameObject GFXController;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the animator located in the GFX.
        animator = GFXController.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /** This is triggered when an interactive object interacts with the pet.
     It gets passed into the pet state AI so that the needs that the interaction is supposed
    to meet are satisfied.
    @param animation
    @param interact
    */

    public void interaction(int animation, Interaction interact) {
        animator.SetInteger("Animation_Part", animation);
        this.GetComponent<PetState>().processInteraction(interact);
        //Debug.Log("Pet Interaction");
    }
}
