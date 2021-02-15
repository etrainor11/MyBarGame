using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    [SerializeField]
    private float interactionLength;

    private NewInventory inventory;

    [SerializeField]
    public List<object> drinkInteractionScripts = new List<object>(5);

    [SerializeField]
    private LayerMask mask;

    public ItemCollection itemCollection;

    public GameObject objectCastingOn;

    private GiveDrinksToCustomer giveToCustomer;

    private void Awake()
    {
        inventory = GetComponent<NewInventory>();
        giveToCustomer = GetComponent<GiveDrinksToCustomer>();

    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Interaction class active");



    }

    private void OnDisable()
    {
        objectCastingOn = null;
        itemCollection = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (objectCastingOn.tag == "DrinkStorage")
            {
                itemCollection.AddItemToInventory();
            }

            if (objectCastingOn.tag == "Customer")
            {
                CustomerScript customerScript = objectCastingOn.GetComponent<CustomerScript>();
                giveToCustomer.GiveCustomerDrinks(customerScript);

            }
        }
        //creates a ray and draws it in the scene view
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, interactionLength, mask);
        //Debug.DrawRay(transform.position, transform.up * interactionLength, Color.green);

        //check if collider hits the DrinkStorage tag
        //if(hit.collider != null)
        //{
        //    //Debug.Log("hitting" + hit.collider.gameObject.name);

        //    if(hit.collider.tag == "DrinkStorage")
        //    {

        //        //reference the itemcollection script on contact
        //        ItemCollection collection = hit.collider.GetComponent<ItemCollection>();

        //        //hit space to query if drink can be picked up
        //        if (Input.GetKeyDown(KeyCode.Space))
        //        {

        //            //check if there is room in inventory
        //            if(inventory.itemInInventory < inventory.inventoryCapacity)
        //            {
        //                Debug.Log("there is space in inventory, now collecting...");

        //                //set the drink in the first null found on the list
        //                int x = inventory.playerDrinks.IndexOf(null);
        //                inventory.playerDrinks[x] = collection.drink;

        //                //set the quality at the same list index;
        //                inventory.drinkQuality[x] = collection.drink.quality;

        //                inventory.NewAssignToDisplay(x);
        //                inventory.itemInInventory = CountItemsInIneventory();
        //                inventory.ListInventoryItems();
        //            }

        //            else
        //            {
        //                Debug.Log("no space in inventory!");
        //            }
        //        }



        //    }

        //    if(hit.collider.tag == "Customer")
        //    {
        //        if(Input.GetKeyDown (KeyCode.Space))
        //        {
        //            //get a reference to the customer script
        //            CustomerScript customerScript = hit.collider.gameObject.GetComponent<CustomerScript>();

        //            for (int i = 0; i < customerScript.drinksWanted.Count; i++)
        //            {

        //                for (int j = 0; j < inventory.playerDrinks.Count; j++)
        //                {

        //                    //Debug.Log("looking for " + customerScript.drinksWanted[i] + " in customer slot number " + i + " in player slot number " + j);


        //                    //to avoid a nullreferenceexeption, if the drinks index is null, skip it to the next iteration of the loop
        //                    if(inventory.playerDrinks[j] == null)
        //                    {
        //                        continue;
        //                    }

        //                    if (customerScript.drinksWanted[i] == inventory.playerDrinks[j].drinks_SOs)
        //                    {
        //                        //Debug.Log("the player has it in slot "  + j);

        //                        //update inventory and the customers requested items
        //                        customerScript.drinksWanted[i] = null;
        //                        inventory.playerDrinks[j] = null;
        //                        inventory.NewAssignToDisplay(j);
        //                        inventory.itemInInventory = CountItemsInIneventory();
        //                        //as well as reset the quality linked to that drink
        //                        inventory.drinkQuality[j] = 0;



        //                        //check if the customer still needs drinks
        //                        customerScript.drinksNeeded = customerScript.checkNumberOfDrinksNeeded();
        //                        customerScript.isWaitng =  customerScript.checkIfCustomerIsDone(customerScript.drinksNeeded);

        //                        //if done - get them away
        //                        if(customerScript.isWaitng == false)
        //                        {
        //                            customerScript.customerLeave();
        //                        }

        //                        break;
        //                    }

        //                }
        //            }
        //        }
        //    }
        //}
    }

    private int CountItemsInIneventory()
    {
        int x = 0;

        foreach (Drink drinks in inventory.playerDrinks)
        {
            if (drinks != null)
            {
                x++;
            }
        }

        return x;
    }


}
