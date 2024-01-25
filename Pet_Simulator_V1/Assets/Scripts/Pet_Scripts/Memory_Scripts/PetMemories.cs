using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
