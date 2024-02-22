using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PetMemories
{
    /** Contains, manipulates and collects memories of interactions
     across .*/

    //Provides a list of memories to be retrieved and added.
    private List<Memory> memoryList;

    /** PetMemories Constructor*/

    public PetMemories() {
        memoryList = new List<Memory>();
    }

    /** Gets the memory list.
     @return memoryList
    */

    public List<Memory> getMemoryList() {
        return memoryList;
    }

    /** Inserts a memory into the memory list.
     @param newMemory
    */

    public void addMemory(Memory newMemory) {
        memoryList.Add(newMemory);
    }

    /** Grabs a list of similar memories over a certain interval. 
     @param IDNum
     @param startDate
     @param endDate
     @return result*/

    public List<Memory> getMemoriesByInterval(int IDNum, DateObj startDate, DateObj endDate) {
        List<Memory> result = memoryList.FindAll(delegate (Memory my)
        {
            return (my.getInteraction().getID() == IDNum);
        });
        result = result.FindAll(delegate (Memory my) {
            DateObj date = my.getDate();
            int numberDaysCurr = ((date.getYear() - 1) * 360 + (date.getMonth() - 1) * 30 + date.getDay());
            int numberDayStart = ((startDate.getYear() - 1) * 360 + (startDate.getMonth() - 1) * 30 + startDate.getDay());
            int numberDayEnd = ((endDate.getYear() - 1) * 360 + (endDate.getMonth() - 1) * 30 + endDate.getDay());
            return numberDaysCurr <= numberDayEnd && numberDaysCurr >= numberDayStart;
        });
        return result;
    }

    /** If the list isn't empty, get the pet's last memory.
     @return memoryList[memoryList.Count - 1]*/

    public Memory getLastMemory() {
        if (memoryList.Count > 0)
        {
            return memoryList[memoryList.Count - 1];
        }
        else {
            return null;
        }
    }

    /** For testing purposes, a print function for the various memories of the
     pet will be created to ensure that the memories are being logged.*/

    public void printMemoryList() {
        for (int i = 0; i < memoryList.Count; i++) {
            Interaction memoryInteract = memoryList[i].getInteraction();
            Debug.Log("ID: " + memoryInteract.getID() + "\n"
                + "Type: " + memoryInteract.getType() + "\n"
                + "Sub-Type: " + memoryInteract.getSub() + "\n"
                + "Name: " + memoryInteract.getName() + "\n");
        }
    }
}
