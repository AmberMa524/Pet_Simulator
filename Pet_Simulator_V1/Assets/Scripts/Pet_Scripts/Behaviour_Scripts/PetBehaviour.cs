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
        //Grabs the interaction catalogue from the GameEnvironment.
        interactionCatalogue = GameEnvironment.currentGame.currentInteractionList;
        //Grabs the learned behavior manager from the GameEnvironment.
        learnedBehaviourManager = GameEnvironment.currentGame.currentLearnedBehaviourManager;
        //Grabs the preference manager from the GameEnvironment.
        preferenceManager = GameEnvironment.currentGame.currentPreferenceManager;
        //Sets up the preference manager with the necessary preference types based on traits.
        foreach (Trait child in GameEnvironment.currentGame.currentTraitList)
        {
            preferenceManager.addPreference(new Preference(child.getType()));
        }
        countDown = 0;
        learnedBehaviorExecuting = false;
    }

    /** Every second, the pet will attempt to perform a random action. */

    void Update() {
            //If the program is still in the process of executing an action,
            //do not perform a new action.
            if (!learnedBehaviorExecuting)
            {
                performAction();
            }
            else
            {
            //Count down of the cooldown time for the player, which terminates once
            //the learned behavior has stopped executing.
                countDown--;
                if (countDown < 0)
                {
                    learnedBehaviorExecuting = false;
                }
            }
    }

    /** Initializes all attributes of the pet's behavior. */

    public void initializer()
    {
        //Grabs the interaction catalogue from the GameEnvironment.
        interactionCatalogue = GameEnvironment.currentGame.currentInteractionList;
        //Grabs the learned behavior manager from the GameEnvironment.
        learnedBehaviourManager = GameEnvironment.currentGame.currentLearnedBehaviourManager;
        //Grabs the preference manager from the GameEnvironment.
        preferenceManager = GameEnvironment.currentGame.currentPreferenceManager;
        //Sets up the preference manager with the necessary preference types based on traits.
        foreach (Trait child in GameEnvironment.currentGame.currentTraitList)
        {
            preferenceManager.addPreference(new Preference(child.getType()));
        }
        countDown = 0;
        learnedBehaviorExecuting = false;
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
        //Alters preference based on the pet's memories and the interaction itself.
        alterPreference(interact, memory);
        //Alters behavior based on the pet's memories and the interaction itself.
        alterBehaviour(interact, memory);
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
        //Gets a list of all the pet's previous interactions of the same type as the parameter interaction.
        List<Interaction> tempList = interactionCatalogue.getInteractionList().FindAll(x => x.getType() == interact.getType());
        //Running ID representing the greatest valid preference.
        int runningID = -1;
        //Running maximum representing the highest enjoyment value of a valid preference.
        int maximum = -1;
        //Loops through all previous interactions of this type.
        for (int i = 0; i < tempList.Count; i++) {
            //Checks if preference is valid.
            if (isValidPreference(tempList[i], memory)) {
                //If it is the first valid preference, set the running ID and maximum
                //to that of this preference.
                if (runningID == -1 && maximum == -1)
                {
                    SubTrait petPref = gameObject.GetComponent<PetPersonality>().getTrait(tempList[i].getType()).getSubTrait(tempList[i].getSub());
                    runningID = tempList[i].getID();
                    maximum = petPref.getValue();
                }
                else {
                    //If it is not the first valid preference, check if this preference is
                    //greater than the current top preference. If it is, then replace the current
                    //top running preference ID and value to this one's.
                    SubTrait petPref = gameObject.GetComponent<PetPersonality>().getTrait(tempList[i].getType()).getSubTrait(tempList[i].getSub());
                    if (petPref.getValue() > maximum) {
                        runningID = tempList[i].getID();
                        maximum = petPref.getValue();
                    }
                }
            }
        }
        //If the running ID and maximum is found, then set the preference for this type to be
        //that of the one that has been found.
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
        //Get the date of the last memory made (the current date).
        DateObj endDate = memory.getLastMemory().getDate();
        //Represents the frequency of the interaction.
        int frequency;
        //If the end date is the first date in the calendar (0001, 01, 01), then the frequency will be counted by the amount of times its' been done in total.
        if (endDate.getMonth() == 1 && endDate.getYear() == 1 && endDate.getDay() < PREFERENCE_DATE_INT + 1)
        {
            frequency = memory.getMemoryList().FindAll(delegate (Memory my)
            {
                return my.getInteraction().getID() == interact.getID();
            }).Count;
        }
        else
        {
            //If the end date is ot the first day on the calendar, then find the start date.
            //Day is calculated by subtracting the designated date interval from the current date.
            int startDay = endDate.getDay() - PREFERENCE_DATE_INT;
            //The year should be about 0-1 years apart.
            int startYear = endDate.getYear();
            //The month should be about 0-1 months apart.
            int startMonth = endDate.getMonth();
            //if the start day is 0 or less, than the start date should be
            //the previous month. The maximum days per month value will be added to the start day (start day
            //should be negative in this case, which should turn it into a positive value within the bounds of 1-30).
            if (startDay <= 0)
            {
                startDay = startDay += 30;
                startMonth--;
            }
            //If the start month is 0 or less, than the start date should be the
            //previous year. The maximum months per year will be added to the start month (start month
            //should be negative in this case, which should turn it into a positive value within the bounds of 1-12).
            if (startMonth <= 0)
            {
                startYear--;
                startMonth = 12;
            }
            //With the start day, month, and year calculated, the start date can be calculated.
            DateObj startDate = new DateObj(startDay, startMonth, startYear);
            //The start date is used to collect all recent memories.
            List<Memory> recentMemories = memory.getMemoriesByInterval(interact.getID(), startDate, endDate);
            //The number of memories found within this interval are counted.
            frequency = recentMemories.Count;
        }
        //If the frequency is within the the bounds of the specified frequency, then it is valid.
        if (frequency < PREFERENCE_FREQUENCY)
        {
            return true;
        }
        else {
            //If it is over the bounds of the specified frequency, then it is invalid.
            return false;
        }
    }

    /** Checks through every memory of this event and averages out the regular time
     that this interaction may occur. Considers the frequency of this act and if it occurs frequently
    enough (three times every three days) */

    private void alterBehaviour(Interaction interact, PetMemories memory)
    {
        //Gets all of the interactions that have been performed over the course of the game.
        List<Interaction> tempList = interactionCatalogue.getInteractionList();
        //Goes through all of these interactions and examines their frequency.
        for (int i = 0; i < tempList.Count; i++) {
            //The learned behavior will be forgotten if it is no longer valid.
            //But will be relearned if it is still valid or becomes valid.
            learnedBehaviourManager.removeLearnedBehavior(tempList[i].getID());
            //If performed enough times over a three day interval, it will be considered valid as a learned behavior.
            if (isValidBehavior(tempList[i], memory)) {
                //The algorithm then calls all of the pet's memories of this interaction in their memory list.
                //Then, the algorithm creates an average time for when these interactions should take place.
                //The pet remembers this and suggests the interaction at that particular time.
                List<Memory> memoryList = memory.getMemoryList().FindAll(x => x.getInteraction().getID() == tempList[i].getID());
                //Gets the sum of all the times performed in seconds.
                int sum = 0;
                for (int j = 0; j < memoryList.Count; j++) {
                    sum += memoryList[j].getTime().getHour() * 60 * 60;
                    sum += memoryList[j].getTime().getMinute() * 60;
                    sum += memoryList[j].getTime().getSecond();
                }
                //The sum is averaged per memory of this event.
                int average = sum / memoryList.Count;
                //The average hour that this interaction typically occurs.
                int hour = average / 60 / 60;
                //The average minute that this interaction typically occurs.
                int minute = average%60;
                //The average second that this interaction typically occurs.
                int second = average%60%60;
                //This time object represents the average time for this interaction,
                //Which would be included in the learned behaviour.
                TimeObj timeobject = new TimeObj(second, minute, hour);
                //Add the new learned behavior.
                learnedBehaviourManager.addLearnedBehaviour(new LearnedBehaviour(timeobject, tempList[i]));
            }
        }
    }

    /** Determines if an interaction is a valid candidate to become a learned behavior. This is primarily based on the frequency
     of the interaction. If the interaction has been done more frequently over a certain period of time than the threshold
    will permit (three times every 3 days), then it is not a valid candidate. This function counts the amount of repeated interactions
    over the learned behavior time interval. If it exceeds the threshold amount, it will be deemed invalid as a learned behavior. If not,
    it will be considered valid.
    */

    private bool isValidBehavior(Interaction interact, PetMemories memory) {
        //Get the date of the last memory made (the current date).
        DateObj endDate = memory.getLastMemory().getDate();
        //Represents the frequency of the interaction.
        int frequency;
        //If the end date is the first date in the calendar (0001, 01, 01), then the frequency will be counted by the amount of times its' been done in total.
        if (endDate.getMonth() == 1 && endDate.getYear() == 1 && endDate.getDay() < LEARNED_BEHAVIOR_DATE_INT + 1)
        {
            frequency = memory.getMemoryList().FindAll(delegate (Memory my)
            {
                return my.getInteraction().getID() == interact.getID();
            }).Count;
        }
        else
        {
            //If the end date is ot the first day on the calendar, then find the start date.
            //Day is calculated by subtracting the designated date interval from the current date.
            int startDay = endDate.getDay() - LEARNED_BEHAVIOR_DATE_INT;
            //The year should be about 0-1 years apart.
            int startYear = endDate.getYear();
            //The months should be about 0-1 months apart.
            int startMonth = endDate.getMonth();
            //if the start day is 0 or less, than the start date should be
            //the previous month. The maximum days per month value will be added to the start day (start day
            //should be negative in this case, which should turn it into a positive value within the bounds of 1-30).
            if (startDay <= 0)
            {
                startDay = startDay += 30;
                startMonth--;
            }
            //If the start month is 0 or less, than the start date should be the
            //previous year. The maximum months per year will be added to the start month (start month
            //should be negative in this case, which should turn it into a positive value within the bounds of 1-12).
            if (startMonth <= 0)
            {
                startYear--;
                startMonth = 12;
            }
            //With the start day, month, and year calculated, the start date can be calculated.
            DateObj startDate = new DateObj(startDay, startMonth, startYear);
            //The start date is used to collect all recent memories.
            List<Memory> recentMemories = memory.getMemoriesByInterval(interact.getID(), startDate, endDate);
            //The number of memories found within this interval are counted.
            frequency = recentMemories.Count;
        }
        //If the frequency is greater than or equal to the minimum frequency, it is valid.
        if (frequency >= LEARNED_BEHAVIOR_FREQUENCY)
        {
            return true;
        }
        else
        {
            //If it is less than the minimum frequency, then it is invalid.
            return false;
        }
    }

    /** Utilizing the information found in the pet's state data, preference manager,
     and learned behavior manager, the pet will suggest an interaction type. */

    public void performAction() {
        //Check if a pet has entered a state.
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
                    //If not, then don't show it.
                    thoughtWindow.SetActive(false);
                }
            }
            else {
                //If not then don't show it.
                thoughtWindow.SetActive(false);
            }
            //If so, then show the thought window with the preferred interaction on it.
            //If not, then do not show the thought window (keep hidden).
        }
        else {
            //If the pet is not in a state, then check if there is a regularly scheduled behavior for that
            //time. If so, then show the interaction for that learned behavior on the thought bubble for the time designated in the learned_behavior action bounds.
            //If not, then keep the thought bubble hidden.

            //Get the current time in the game.
            GameTime currentTime = GameEnvironment.getGameTime();
            GameClock currentClock = currentTime.getClock();
            
            //Search the learned behavior manager to find if there is a behavior scheduled for that particular hour and minute.
            LearnedBehaviour search = learnedBehaviourManager.getBehaviourList().Find(x => x.getTime().getHour() == currentClock.getHour() && x.getTime().getMinute() == currentClock.getMinute());
            //If the search is successful, perform the learned behavior action by having the pet suggest the action.
            if (search != null)
            {
                countDown = LEARNED_BEHAVIOUR_ACTION_BOUNDS;
                thoughtWindow.SetActive(true);
                GameObject.FindGameObjectWithTag("ThoughtElements").GetComponent<ThoughtSpriteChange>().ChangeSprite(search.getAction().getSprite());
                GameObject.FindGameObjectWithTag("ThoughtBubble").GetComponent<ThoughtSpriteChange>().ChangeSprite(1);
                learnedBehaviorExecuting = true;
            }
            else {
                //If the search is not successful do not show the window at all.
                thoughtWindow.SetActive(false);
            }
            
        }
    }
}
