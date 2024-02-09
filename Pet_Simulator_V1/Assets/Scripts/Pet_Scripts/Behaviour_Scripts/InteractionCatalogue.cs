using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCatalogue
{
    /** A script that catalogues each unique interaction the pet has been
     exposed to. This will be used in cases where a prefernce is lost due to overexposure.
    In such a case, a new preference should be born as a result. All entries in the interaction
    list will be unique, so repeated interactions will be discarded.
    */

    //The list of interactions included in the catalogue.
    private List<Interaction> interactionList;

    //Ineteraction catalogue constructor.
    public InteractionCatalogue() {
        interactionList = new List<Interaction>();
    }

    /** Gets the list of interactions. 
     @return interactionList*/
    public List<Interaction> getInteractionList() {
        return interactionList;
    }

    /** If this interaction does not exist in the interaction list, 
     then it can be added.
    @param newInteract*/

    public void addInteraction(Interaction newInteract) {
        if (interactionList.Find(x => x.getID() == newInteract.getID()) == null) {
            interactionList.Add(newInteract);
        }
    }
}
