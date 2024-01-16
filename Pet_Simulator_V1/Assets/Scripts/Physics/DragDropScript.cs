using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropScript : MonoBehaviour
{

    /** 
     * Controls the dragging and dropping of items in the scene.
     * 
     * Reference for this script:
     * https://www.youtube.com/watch?v=pFpK4-EqHXQ
     */

    //Gets the position of the cursor.

    Vector3 mousePosition;

    //Gets the initial position of the cursor.

    Vector3 initPos;

    //Bool describing whether or not item has been grabbed.
    
    bool grabbed;

    //Bool describing whether or not the item is touching the pet.

    bool touchingPet;

    /**
     * When the game starts the item is marked as ungrabbed. 
     */

    void Start() {
        grabbed = false;
        touchingPet = false;
        initPos = transform.position;
    }

    /** The game determines if the item was grabbed or not. If it was grabbed,
     * then the cursor should continue dragging. Otherwise, the item should not
     * be dragging in the environment.
     */

    void Update() {
        if (grabbed)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        }

        //Debug.Log("Touching Pet" + touchingPet);
    }

    /** 
        Gets the current position of the cursor.
        @return Camera.main.WorldToScreenPoint(transform.position)
     */

    private Vector3 GetMousePos() {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    /** If the item is clicked, grabbed becomes true and the player can drag the item. If clicked again while grabbed is true
     grabbed is false and the player drops the item. */

    private void OnMouseDown() {
        if (grabbed)
        {
            if (touchingPet)
            {
                Debug.Log("Pet Interaction");
            }
            touchingPet = false;
            grabbed = false;
            mousePosition = initPos;
            transform.position = initPos;
        }
        else {
            mousePosition = Input.mousePosition - GetMousePos();
            grabbed = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pet")
        {
            touchingPet = true;
        }
        else {
            touchingPet = false;
        }
    }

}
