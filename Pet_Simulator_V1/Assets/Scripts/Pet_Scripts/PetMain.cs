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

    //A pet memory object to hold all of the pet's memories.
    private PetMemories memories;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the animator located in the GFX.
        animator = GFXController.GetComponent<Animator>();
        memories = new PetMemories();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        //memories.printMemoryList();
    }
}
