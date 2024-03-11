using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveObject : MonoBehaviour
{

    /** 
     * This is the code for the interactive objects in the game.
     * Each one contains an interactive object, which gets passed between
     * the interactive object to the pet if the player clicks on the pet with
     * the item grabbed.
     * 
     * Reference for this script:
     * https://www.youtube.com/watch?v=pFpK4-EqHXQ
     */

    public const int MAX_LETTER = 7;

    ////////////////////////////////
    //////Grabbing and Physics//////
    ////////////////////////////////

    //Gets the position of the cursor.

    private Vector3 mousePosition;

    //Gets the initial position of the cursor.

    private Vector3 initPos;

    //Bool describing whether or not item has been grabbed.

    private bool grabbed;

    //Bool describing whether or not the item is touching the pet.

    private bool touchingPet;

    //Identifies the interaction in the game.

    public int interactionID;

    //Identifies the type of interaction in the game.

    public string interactionType;

    //Identifies the interaction subtype in the game.

    public string interactionSubType;

    //Identifies the interaction sprite index in the game.

    public int interactionSpriteIndex;

    //Provides a description of the interaction.

    public string interactionName;

    //Returns true if the pet is touching a trash can.

    private bool touchingTrash;

    ////////////////////////////////
    /////Interaction Components/////
    ////////////////////////////////

    //All Interactable Objects will have an interaction object
    //attached to them, which should be placed in this parameter.
    private Interaction interaction;

    ////////////////////////////////
    //////Animation Components//////
    ////////////////////////////////

    //Represents the index of the animation that should play upon interaction.
    public int ani_num;

    ////////////////////////////////
    /////////Child Objects//////////
    ////////////////////////////////
    
    //The annotation window that shows the player the stats of the item they've selected.

    public GameObject annotation;

    //Represents the name of the object in the annotation window.

    public TMP_Text title;

    //Represents the type of the object in the annotation window.

    public TMP_Text type_name;

    //Represents the sub type of the object in the annotation window.

    public TMP_Text sub_type_name;

    /**
     * When the game starts the item is marked as ungrabbed. 
     */

    void Start()
    {
        generateText();
        annotation.SetActive(false);
        grabbed = false;
        touchingPet = false;
        touchingTrash = false;
        interaction = new Interaction(interactionID, interactionType, interactionName, interactionSubType, interactionSpriteIndex);
    }

    /** The game determines if the item was grabbed or not. If it was grabbed,
     * then the cursor should continue dragging. Otherwise, the item should not
     * be dragging in the environment.
     */

    void Update()
    {
        if (grabbed)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        }
    }

    /** Responds to when the player hovers over the object before it is grabbed.*/

    void OnMouseOver()
    {
        if (!grabbed) {
           annotation.SetActive(true);
           if (!touchingPet && !touchingTrash)
           {
               gameObject.GetComponent<SpriteRenderer>().color = new Color32(99, 99, 99, 255);
           }
        }
    }

    /** Responds to when the player stops hovering.*/

    void OnMouseExit() {
        annotation.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }


    /** 
        Gets the current position of the cursor.
        @return Camera.main.WorldToScreenPoint(transform.position)
     */

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    /** If the item is clicked, grabbed becomes true and the player can drag the item. If clicked again while grabbed is true
     grabbed is false and the player drops the item. If the item interacts with the player or is thrown into the garbage,
    the item will be destroyed.*/

    private void OnMouseDown()
    {
        if (grabbed)
        {
            if (touchingPet) {
                GameObject.FindGameObjectsWithTag("Pet")[0].GetComponent<PetMain>().interaction(ani_num, interaction);
                if (AudioController.gameSounds != null && AudioController.gameSounds.Length > 0)
                  {
                        AudioController.gameSounds[0].Play();
                  }
                Destroy(gameObject);
            }
            if (touchingTrash) {
                AudioController.gameSounds[1].Play();
                Destroy(gameObject);
            }
            touchingPet = false;
            touchingTrash = false;
            grabbed = false;
        }
        else
        {
            mousePosition = Input.mousePosition - GetMousePos();
            grabbed = true;
        }
    }

    /** Detects collisions with triggers and handles them.
     @param other*/

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Pet")
        {
            touchingPet = true;
        }
        else if (other.GetComponent<Collider>().tag == "Destroyer")
        {
            touchingTrash = true;
        }
    }

    /** Detects exits from triggers and handles them.
     @param other.
    */

    void OnTriggerExit(Collider other)
    {
        touchingPet = false;
        touchingTrash = false;
    }

    /** Generates the text bubble for the item. */

    private void generateText() {

        title.text = interactionName;
        type_name.text = interactionType;
        sub_type_name.text = interactionSubType;

    }
}
