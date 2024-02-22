using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMain : MonoBehaviour
{
    /** This is the pet's main controller, which will control its memories.
     * The interactions and calculations will be performed through this script.*/

    //Animation Values
    //Manipulates animations for pet.
    private Animator animator;
    //Gets the GFX object that controls the sprite animations.
    public GameObject GFXController;

    //A pet memory object to hold all of the pet's memories.
    private PetMemories memories;

    //There can only be one instance of the pet at a time.
    public static PetMain Instance;

    /**
    Sets up the pet's memories and animation controller.
    Specifies to not destroy the pet upon loading the next scene in the game.
    Pet should be terminated when the game terminates.
    Only one pet can exist at a time.
    */
    void Start()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        Debug.Log("Current Game: " + GameEnvironment.currentGame);
        memories = GameEnvironment.currentGame.currentMemory;
        //Gets the animator located in the GFX.
        animator = GFXController.GetComponent<Animator>();
        DontDestroyOnLoad(gameObject);
    }

    /** This is triggered when an interactive object interacts with the pet.
     It gets passed into the pet state AI so that the needs that the interaction is supposed
    to meet are satisfied. Pet should log the time and date of the interaction in the form
    of a memory, which would then be placed in its' memory system.
    @param animation
    @param interact
    */

    public void interaction(int animation, Interaction interact) {
        //Plays the associated animation for the interaction.
        animator.SetInteger("Animation_Part", animation);
        //The pet state is altered depending on the type of interaction performed.
        this.GetComponent<PetState>().processInteraction(interact);
        //Gets the current Date.
        GameCalendar currentDate = GameEnvironment.getGameTime().getCal();
        //Gets the current time
        GameClock currentTime = GameEnvironment.getGameTime().getClock();
        //Creates a time stamp object that logs the time of the interaction.
        TimeObj newTime = new TimeObj(currentTime.getSecond(), currentTime.getMinute(), currentTime.getHour());
        //Logs the date of the interaction through date object.
        DateObj newDate = new DateObj(currentDate.getDay(), currentDate.getMonth(), currentDate.getYear());
        //Memory object was created using the date, time, and interact objects.
        Memory insertMemory = new Memory(newDate, newTime, interact);
        //Adds the memory to the pet's collection of memories.
        memories.addMemory(insertMemory);
        //REMOVE IF CLAUSE, ONLY NECESSARY FOR SPRINT 1 TEST, as behavior object was not a part of the pet for that one.
        if (gameObject.GetComponent<PetBehaviour>() != null) {
            //In any other case, process the interaction for the pet.
            gameObject.GetComponent<PetBehaviour>().processInteraction(interact, memories, newTime);
        }
    }
}
