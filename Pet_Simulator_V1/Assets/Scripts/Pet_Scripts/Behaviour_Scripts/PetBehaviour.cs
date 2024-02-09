using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBehaviour : MonoBehaviour
{

    /** Manages the pet's preferences and learned behaviors. */

    //A preference manager object, which manages the pet's preferences.
    private PreferenceManager preferenceManager;

    //Determines the bounds of time that the learned behavior may be recommended between.
    public int LEARNED_BEHAVIOUR_ACTION_BOUNDS;

    //Represents the maximum number of repeated interactions
    //per interval when determining preferences.
    private const int PREFERENCE_FREQUENCY = 5;

    //Represents the date interval in which the frequency
    //of interactions will be checked to determine preference.
    private const int PREFERENCE_DATE_INT = 2;

    //Represents the minimum number of repeated interactions
    //per interval when determining learned behaviors.
    private const int LEARNED_BEHAVIOR_FREQUENCY = 3;

    //Represents the date interval in which the frequency
    //of interactions will be checked to determine learned behaviors.
    private const int LEARNED_BEHAVIOR_DATE_INT = 3;

    //Returns true if a learned behavior is currently executing;
    private bool learnedBehaviorExecuting;

    //Counts down the amount of miliseconds a learned behavior suggestion will come up for.
    private int countDown;
    
    //Serves to manage the unique interactions experienced by the pet.
    private InteractionCatalogue interactionCatalogue;

    //A learned behaviour manager that manages all of the pet's learned behaviours.
    private LearnedBehaviourManager learnedBehaviourManager;

    //Represents the pet's thought bubble, which will serve as its' prime behavior.
    public GameObject thoughtWindow;

    /** Sets up the learned behavior and preference managers. Preferences are
     developed based on traits found in the pet's data.*/
    void Start()
    {
        interactionCatalogue = new InteractionCatalogue();
        learnedBehaviourManager = new LearnedBehaviourManager();
        preferenceManager = new PreferenceManager();
        GameObject traitObject = this.gameObject.transform.Find("Traits").gameObject;
        foreach (Transform child in traitObject.transform)
        {
            if (child.tag == "Trait")
            {
                preferenceManager.addPreference(new Preference(child.GetComponent<Trait>().getType()));
            }
        }
        countDown = 0;
        learnedBehaviorExecuting = false;
    }

    /** Every second, the pet will attempt to perform a random action. */

    void Update() {
        if (!learnedBehaviorExecuting)
        {
            performAction();
        }
        else {
            countDown--;
            if (countDown < 0) {
                learnedBehaviorExecuting = false;
            }
        }
    }

    /** Gets the preference manager for the pet's personality.
     @return preferenceManager
    */

    public PreferenceManager getPreferenceManager()
    {
        return preferenceManager;
    }

    /** Takes in the current interaction and processes it to change the pet's preference.
     The process should involve the evaluation of the frequency of the interaction mixed with
    whether the pet enjoys interactions of the interaction's subtype. A learned behaviour may
    be developed depeding on the frequency of the act, and a median average time may be determined,
    by the pet's memory of it.
    @param interact
    @param memory
    */

    public void processInteraction(Interaction interact, PetMemories memory, TimeObj time)
    {
        //Should automatically reject the addition if it has been already added.
        interactionCatalogue.addInteraction(interact);
        alterPreference(interact, memory);
        //LearnedBehaviour newBehaviour = new LearnedBehaviour(time, interact);
        //preferenceManager.setPreference(interact);
        //learnedBehaviourManager.addLearnedBehaviour(newBehaviour);
        //learnedBehaviourManager.printBehaviours();
    }

    /** Takes in the most recent interaction and the memory manager. Using these two objects,
     the algorithm looks at all the various interactions of the most recent interaction's type
    and weighs them against each other to see which one will become the new preference based
    on their frequency (validity) and preferential value (priority). Once it's done, a new preference
    should be generated.
    @param memory
    @param interact
    */

    private void alterPreference(Interaction interact, PetMemories memory) {
        List<Interaction> tempList = interactionCatalogue.getInteractionList().FindAll(x => x.getType() == interact.getType());
        int runningID = -1;
        int maximum = -1;
        for (int i = 0; i < tempList.Count; i++) {
            if (isValidPreference(tempList[i], memory)) {
                if (runningID == -1 && maximum == -1)
                {
                    SubTrait petPref = gameObject.GetComponent<PetPersonality>().getTrait(tempList[i].getType()).getSubTrait(tempList[i].getSub());
                    runningID = tempList[i].getID();
                    maximum = petPref.getValue();
                }
                else {
                    SubTrait petPref = gameObject.GetComponent<PetPersonality>().getTrait(tempList[i].getType()).getSubTrait(tempList[i].getSub());
                    if (petPref.getValue() > maximum) {
                        runningID = tempList[i].getID();
                        maximum = petPref.getValue();
                    }
                }
            }
        }
        if (runningID != -1 && maximum != -1) {
            preferenceManager.setPreference(tempList.Find(x => x.getID() == runningID));
        }
    }

    /** Determines if an interaction is a valid candidate to become a preference. This is primarily based on the frequency
     of the interaction. If the interaction has been done more frequently over a certain period of time than the threshold
    will permit (five times every 2 days), then it is not a valid candidate. This function counts the amount of repeated interactions
    over the preference time interval. If it exceeds the threshold amount, it will be deemed invalid as a preference. If not,
    it will be considered valid.
    */

    private bool isValidPreference(Interaction interact, PetMemories memory) {
        SubTrait petPref = gameObject.GetComponent<PetPersonality>().getTrait(interact.getType()).getSubTrait(interact.getSub());
        DateObj endDate = memory.getLastMemory().getDate();
        int frequency;
        if (endDate.getMonth() == 1 && endDate.getYear() == 1 && endDate.getDay() < PREFERENCE_DATE_INT + 1)
        {
            frequency = memory.getMemoryList().FindAll(delegate (Memory my)
            {
                return my.getInteraction().getID() == interact.getID();
            }).Count;
        }
        else
        {
            int startDay = endDate.getDay() - PREFERENCE_DATE_INT;
            int startYear = endDate.getYear();
            int startMonth = endDate.getMonth();
            if (startDay <= 0)
            {
                startDay = startDay += 30;
                startMonth--;
            }
            if (startMonth <= 0)
            {
                startYear--;
                startMonth = 12;
            }
            DateObj startDate = new DateObj(startDay, startMonth, startYear);
            List<Memory> recentMemories = memory.getMemoriesByInterval(interact.getID(), startDate, endDate);
            frequency = recentMemories.Count;
        }
        if (frequency < PREFERENCE_FREQUENCY)
        {
            return true;
        }
        else {
            return false;
        }
    }

    /** Checks through every memory of this event and averages out the regular time
     that this interaction may occur. Considers the frequency of this act and if it occurs frequently
    enough (once every three days) */

    private void alterBehaviour()
    {

    }

    /** Utilizing the information found in the pet's state data, preference manager,
     and learned behavior manager, the pet will suggest an interaction type. */

    public void performAction() {
        //Check if a pet has entered a state
        PetState currentPetState = gameObject.GetComponent<PetState>();
        if (currentPetState.isFound())
        {
            //If the pet is currently in a state, check what state it is.
            //Then, depending on the type of state, check if the pet has any particular
            //preference within that state.
            string type = currentPetState.getState().getType();
            Preference prefByType = preferenceManager.getPreferenceByType(type);
            if (prefByType != null)
            {
                //If the preference has an interaction associated with it, then
                //display the sprite for that interaction on the pet's window.
                if (prefByType.getInteraction() != null)
                {
                    thoughtWindow.SetActive(true);
                    GameObject.FindGameObjectWithTag("ThoughtBubble").GetComponent<ThoughtSpriteChange>().ChangeSprite(0);
                    GameObject.FindGameObjectWithTag("ThoughtElements").GetComponent<ThoughtSpriteChange>().ChangeSprite(prefByType.getInteraction().getSprite());
                }
                else {
                    thoughtWindow.SetActive(false);
                }
            }
            else {
                thoughtWindow.SetActive(false);
            }
            //If so, then show the thought window with the preferred interaction on it.
            //If not, then do not show the thought window (keep hidden).
        }
        else {
            //If the pet is not in a state, then check if there is a regularly scheduled behavior for that
            //time. If so, then show the interaction for that learned behavior on the thought bubble for the time designated in the learned_behavior action bounds.
            //If not, then keep the thought bubble hidden.
            GameTime currentTime = GameEnvironment.getGameTime();
            GameClock currentClock = currentTime.getClock();
            LearnedBehaviour search = learnedBehaviourManager.getBehaviourList().Find(x => x.getTime().getHour() == currentClock.getHour() && x.getTime().getMinute() == currentClock.getMinute());
            if (search != null)
            {
                countDown = LEARNED_BEHAVIOUR_ACTION_BOUNDS;
                thoughtWindow.SetActive(true);
                GameObject.FindGameObjectWithTag("ThoughtElements").GetComponent<ThoughtSpriteChange>().ChangeSprite(search.getAction().getSprite());
                GameObject.FindGameObjectWithTag("ThoughtBubble").GetComponent<ThoughtSpriteChange>().ChangeSprite(1);
                learnedBehaviorExecuting = true;
            }
            else {
                thoughtWindow.SetActive(false);
            }
        }
    }
}
