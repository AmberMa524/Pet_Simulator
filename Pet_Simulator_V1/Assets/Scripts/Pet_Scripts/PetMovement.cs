using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** NOTE: Change this later so that each state is its own entity and can be
 executed abstractly. */

public class PetMovement : MonoBehaviour
{
    /** This is the script that controls the pet's movement depending on the state of the
     pet. During each movement, the pet's animations will change. */

    //Movement Values
    //Represents the rate at which an idle pet will move around the room (singular movements).
    private const int MOVE_RATE = 200;
    //Represents the amount of steps per motion.
    private const float SPEED = 2.0f;
    //The maximum number of moves during idle state.
    private const int IDLE_MOVE_COUNT = 3;
    //The maximum number of seconds the pet must be idle for in idle state.
    private const int IDLE_COUNT = 200;
    //The maximum x value that the pet is allowed to move.
    public float maxBound;
    //The minimum x value that the pet is allowed to move.
    public float minBound;
    //Determines whether pet is in idle state.
    private bool idle;
    //Counts the number of moves left in idle state.
    private int moveCount;
    //Counts the number of seconds to be idle.
    private int idleCount;
    //If true, the pet moves left, if false, the pet moves right.
    private bool direction;

    //Animation Values
    //Manipulates animations for pet.
    private Animator animator;
    //Gets the GFX object that controls the sprite animations.
    public GameObject GFXController;

    /** Pet Movement constructor.
     * Sets up the pet's assets to their default settings.
     pet starts in the Idle state first.*/
    void Start()
    {
        //Gets the animator located in the GFX.
        animator = GFXController.GetComponent<Animator>();
        moveCount = IDLE_MOVE_COUNT;
        idleCount = IDLE_COUNT;
        idle = true;
        direction = true;
    }

    /** It detects the current state of the pet and makes alterations to its
     * movement in accordance with the pet's state.*/
    void Update()
    {
        if (idle)
        {
            idleState();
        }
        
    }

    /** 
     * Represents the pet in its' idle state. The
     pet will remain idle for a small amount of time,
    then move either left or right depending on a random
    number generator. Then, the state will continue to loop
    until its' state changes.
    */

    private void idleState() {
            if (idleCount > 0)
            {
                idleCount--;
                animator.SetInteger("Animation_Part", 0);
            }
            else
            {
                if (moveCount > 0)
                {
                    if (direction)
                    {
                        moveLeft();
                    }
                    else
                    {
                        moveRight();
                    }
                    moveCount--;
                }
                else
                {
                    int randomNumber = Random.Range(0, 2);
                    if (randomNumber == 0)
                    {
                        direction = true;
                    }
                    else
                    {
                        direction = false;
                    }
                    moveCount = IDLE_MOVE_COUNT;
                    idleCount = IDLE_COUNT;
                }
            }
    }

    /**Moves the pet left as long as its' x value is greater than or
     equal to the minimum bound of the environment.*/

    private void moveLeft() {
        if (transform.position.x-SPEED >= minBound) {
            animator.SetInteger("Animation_Part", 3);
            transform.position += (new Vector3(-SPEED, 0, 0));
        }
    }

    /**Moves the pet right as long as its' x value is less than or
     equal to the maximum bound of the environment.*/

    private void moveRight() {
        if (transform.position.x+SPEED <= maxBound)
        {
            animator.SetInteger("Animation_Part", 2);
            transform.position += (new Vector3(SPEED, 0, 0));
        }
    }

    /** 
     * This handles collisions with the pet, depending on
     the state that the pet is in.
    @param collision
     */

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            idle = false;
            animator.SetInteger("Animation_Part", 0);
        }
    }

    /** This handles the ends of collisions with the pet, depending
     on the state that the pet is in.
     @param collision
    */

    void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "Item")
        {
            idle = true;
            animator.SetInteger("Animation_Part", 0);
        }
    }
}
