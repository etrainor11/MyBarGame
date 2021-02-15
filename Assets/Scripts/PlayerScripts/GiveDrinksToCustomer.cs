using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDrinksToCustomer : MonoBehaviour
{
    //private CustomerScript customer;
    [SerializeField]
    private NewInventory inventory;


    public void GiveCustomerDrinks(CustomerScript customer)
    {
        for (int i = 0; i < customer.drinksWanted.Count; i++)
        {
            for (int j = 0; j < inventory.playerDrinks.Count; j++)
            {
                Debug.Log("looking for " + customer.drinksWanted[i] + " in customer slot number " + i + " in player slot number " + j);


                //to avoid a nullreferenceexeption, if the drinks index is null, skip it to the next iteration of the loop
                if (inventory.playerDrinks[j] == null)
                {
                    continue;
                }

                if (customer.drinksWanted[i] == inventory.playerDrinks[j].drinks_SOs)
                {
                    //Debug.Log("the player has it in slot "  + j);

                    //update inventory and the customers requested items
                    customer.drinksWanted[i] = null;
                    inventory.playerDrinks[j] = null;
                    inventory.NewAssignToDisplay(j);
                    inventory.itemInInventory = inventory.CountItemsInIneventory();
                    //as well as reset the quality linked to that drink
                    inventory.drinkQuality[j] = 0;



                    //check if the customer still needs drinks
                    customer.drinksNeeded = customer.checkNumberOfDrinksNeeded();
                    customer.isWaitng = customer.checkIfCustomerIsDone(customer.drinksNeeded);

                    //if done - get them away
                    if (customer.isWaitng == false)
                    {
                        customer.customerLeave();
                    }

                    break;
                }
            }
        }

    }
}
