using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialScroller : MonoBehaviour
{
    /** Allows a player to scroll through a given tutorial. */

    //Represents the page the player is currently on.
    private int currentPage;

    //Represents the screen the player will return to.
    public string returnPage;

    /** Initializes the page number to the first tutorial page.*/
    void Start()
    {
        currentPage = 0;
        if(GameEnvironment.currentTutorial != null)
        {
            updatePage();
        }
    }

    /** Detects if the player is pressing the right or left key.
     If the player is pressing the right key, they should go to the
    next page. If the player is pressing the left key, they should
    go to the previous page. The page will then update accordingly.*/
    void Update()
    {
        Debug.Log(currentPage);
        if (GameEnvironment.currentTutorial != null)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentPage++;
            }
            else if ((Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                currentPage--;
            }
            if (currentPage >= GameEnvironment.currentTutorial.getScreens().Count)
            {
                currentPage = 0;
            }
            else if (currentPage < 0)
            {
                currentPage = GameEnvironment.currentTutorial.getScreens().Count - 1;
            }
            updatePage();
        }
    }

    /** Updates the page according to the current page for the current tutorial. */

    private void updatePage() {
        gameObject.GetComponent<Image>().sprite = GameEnvironment.currentTutorial.getScreens()[currentPage];
    }

    /** Returns the player to the tutorial screen and wipes the tutorial value
     clean from the game environment.*/

    public void returnToTutorialScreen() {
        GameEnvironment.currentTutorial = null;
        SceneManager.LoadScene(returnPage);
    }
}
