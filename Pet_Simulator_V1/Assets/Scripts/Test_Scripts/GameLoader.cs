using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    /** 
     * TESTSCRIPT:: This will not be used in the final game, but will be used to exemplify data
     * saving and loading.
     * 
     * 
     * Designed to read and write game data from a file (JSON). Then, load it wherever it is needed.
     */

    /** Standard data wrapper, which holds test game data.*/

    [SerializeField] public class DataWrapper { 
        public List<int> _GameData = new List<int>(); 
    }

    /** Data wrapper object to save and load into the game.*/

    public DataWrapper dataHolder = new DataWrapper();

    /** Adds a bunch of data to the datawrapper, and then saves
     it to a file by converting it to JSON.*/

    public void SaveIntoJson()
    {
        dataHolder._GameData.Add(0);
        dataHolder._GameData.Add(1);
        dataHolder._GameData.Add(2);
        dataHolder._GameData.Add(3);
        string game = JsonUtility.ToJson(dataHolder);
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/GameData.json", game);
        System.IO.File.WriteAllText("./GameData.json", game);
    }

    /** Load the data from the JSON file.*/

    public void LoadIntoObject() {
        string data = System.IO.File.ReadAllText("./GameData.json");
        Debug.Log(data);
        List<int> numberList = JsonUtility.FromJson<DataWrapper>(data)._GameData;
        for (int i = 0; i < numberList.Count; i++) {
            Debug.Log(numberList[i]);
        }
    }

}
