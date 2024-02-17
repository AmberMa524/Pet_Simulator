using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    /** Designed to read and write game data from a file (JSON). Then, load it wherever it is needed.
     */

    [SerializeField] public class DataWrapper { 
        public List<int> _GameData = new List<int>(); 
    }

    public DataWrapper dataHolder = new DataWrapper();

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

    public void LoadIntoObject() {
        string data = System.IO.File.ReadAllText("./GameData.json");
        Debug.Log(data);
        List<int> numberList = JsonUtility.FromJson<DataWrapper>(data)._GameData;
        for (int i = 0; i < numberList.Count; i++) {
            Debug.Log(numberList[i]);
        }
    }

}
