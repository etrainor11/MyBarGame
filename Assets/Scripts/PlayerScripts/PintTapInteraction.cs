using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintTapInteraction : MonoBehaviour
{

    private DetectRaycastObject detect;
    private NewInventory inventory;
    private ItemCollection collection;
    private void Awake()
    {
        //reference the Raycast script
        detect = GetComponent<DetectRaycastObject>();
        inventory = GetComponent<NewInventory>();
    }

    private void OnEnable()
    {
        collection = detect.Hit2D.collider.GetComponent<ItemCollection>();
        if(collection == null)
        {
            Debug.LogError("Item collection is not set to anything!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(detect.InteractionoKey))
        {
            //get the pint here
            
            //check if there is room in inventory
            if (inventory.itemInInventory < inventory.inventoryCapacity)
            {
                Debug.Log("there is space in inventory, now collecting...");

                //set the drink in the first null found on the list
                int x = inventory.playerDrinks.IndexOf(null);
                inventory.playerDrinks[x] = collection.drink;

                //set the quality at the same list index;
                inventory.drinkQuality[x] = collection.drink.quality;

                inventory.NewAssignToDisplay(x);
                inventory.itemInInventory = inventory.CountItemsInIneventory();
                inventory.ListInventoryItems();
            }

            else
            {
                Debug.Log("no space in inventory!");
            }
        }
    }
}
