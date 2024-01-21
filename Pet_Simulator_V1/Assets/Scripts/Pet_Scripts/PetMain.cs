using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMain : MonoBehaviour
{

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

    public void interaction(int animation) {
        animator.SetInteger("Animation_Part", animation);
        Debug.Log("Pet Interaction");
    }
}
