using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemFactory : MonoBehaviour
{
    /** Designed to create a specified number of game objects of type interactiveObject.
     The factory contains its own canvas, which displays a catalogue of different items that can
     be created.
    */

    public GameObject spawnPoint;

    public List<GameObject> objectList;

    private int currentPage;

    public GameObject mainCanvas;

    public TMP_Text nameVal;

    public TMP_Text type;

    public TMP_Text subtype;

    public Image imageVal;

    private bool clicked;

    // Start is called before the first frame update
    void Start()
    {
        resetFactory();
    }

    // Update is called once per frame
    void Update()
    {
        updatePage();
    }

    public void prevPage()
    {
        if (objectList != null)
        {
            currentPage--;
            if (currentPage < 0)
            {
                currentPage = objectList.Count - 1;
            }
        }
    }

    public void nextPage()
    {
        if (objectList != null)
        {
            currentPage++;
            if (currentPage >= objectList.Count) {
                currentPage = 0;
            }
        }
    }

    public void resetFactory() {
        currentPage = 0;
        unclick();
        mainCanvas.SetActive(false);
    }

    void OnMouseDown()
    {
        if (!clicked)
        {
            click();
            mainCanvas.SetActive(true);
        }
    }

    public void unclick()
    {
        clicked = false;
    }

    public void click() {
        clicked = true;
    }

    public void produceItem() {
        GameObject newObject = Instantiate(objectList[currentPage]);
        newObject.transform.position = spawnPoint.transform.position;
    }

    public void updatePage() {
        if (objectList != null) {
            nameVal.text = objectList[currentPage].GetComponent<InteractiveObject>().interactionName;
            type.text = objectList[currentPage].GetComponent<InteractiveObject>().interactionType;
            subtype.text = objectList[currentPage].GetComponent<InteractiveObject>().interactionSubType;
            imageVal.sprite = objectList[currentPage].GetComponent<SpriteRenderer>().sprite;
        }
    }

}
