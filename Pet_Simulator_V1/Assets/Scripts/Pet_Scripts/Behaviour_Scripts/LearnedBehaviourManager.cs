using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnedBehaviourManager
{

    /** Maintains a list of learned behaviours, which can be added to during the game.*/

    List<LearnedBehaviour> learnedBehaviourList;

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
