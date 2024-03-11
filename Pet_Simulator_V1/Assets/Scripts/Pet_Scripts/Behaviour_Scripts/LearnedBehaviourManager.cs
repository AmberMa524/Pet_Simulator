using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Since this data will need to be saved and loaded,
 this data is serializable.*/

[System.Serializable]
public class LearnedBehaviourManager
{

    /** Maintains a list of learned behaviours, which can be added to during the game.*/

    [SerializeField] List<LearnedBehaviour> learnedBehaviourList;

    /** Learned Behaviour Manager default constructor. */
    public LearnedBehaviourManager()
    {
        learnedBehaviourList = new List<LearnedBehaviour>();
    }

    /** Adds a learned behaviour to the learned behaviour list. Note that
     * each interaction ID can only be inserted once and that all entries must be unique.
     @param newPref
    */

    public void addLearnedBehaviour(LearnedBehaviour lb)
    {
        LearnedBehaviour find = learnedBehaviourList.Find(x => x.getAction().getID() == lb.getAction().getID());
        if (find == null)
        {
            learnedBehaviourList.Add(lb);
            Debug.Log("Added: " + lb.getAction().getName());
        }
    }

    /** Returns true if an interaction of the designated ID number exists.
     @param idNum
     @return true
    */

    private bool isIncluded(int idNum) {
        if (learnedBehaviourList.Find(x => x.getAction().getID() == idNum) != null)
        {
            return true;
        }
        else {
            return false;
         }
    }

    /** Removes the learned behavior specified in the parameters from the list.
     @param idNum
    */

    public void removeLearnedBehavior(int idNum) {
        if (isIncluded(idNum)) {
            int position = learnedBehaviourList.IndexOf(learnedBehaviourList.Find(x => x.getAction().getID() == idNum));
            learnedBehaviourList.RemoveAt(position);
        }
    }

    /** This script will be used for testing purposes to ensure that the learned behaviour manager 
     is loading properly.
    */

    public void printBehaviours()
    {
        for (int i = 0; i < learnedBehaviourList.Count; i++)
        {
            Debug.Log("Interaction : " + learnedBehaviourList[i].getAction().getName() + "\n"
                + "Time : " + learnedBehaviourList[i].getTime().getHour() + ":" + learnedBehaviourList[i].getTime().getMinute());
        }
    }

    /** Returns the behavior list.
     @return learnedBehaviorList
    */

    public List<LearnedBehaviour> getBehaviourList() {
        return learnedBehaviourList;
    }
}
