using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintTapInteraction : MonoBehaviour
{

    private DetectRaycastObject detect;
    private NewInventory inventory;
    private ItemCollection collection;

    
    public GameObject TapUI;
    private void Awake()
    {
        //reference the Raycast script
        detect = GetComponent<DetectRaycastObject>();
        inventory = GetComponent<NewInventory>();
    }

    private void OnEnable()
    {
        //we will be activating and deactivating elements in this list on enable and disable, to save us calling Update and help performance.

        collection = detect.Hit2D.collider.GetComponent<ItemCollection>();
        if (collection == null)
        {
            Debug.LogError("Item collection is not set to anything!");
        }

        if(collection.gameObject.tag == "DrinkStorage")
        {
            Debug.Log("casting on the " + collection.drink.drinks_SOs.DrinkName + " tap");
            //turn the UI for the tap on and obatin a gameobject reference for it
            TapUI = collection.LinkedUI;
            collection.ToggleUI();
        }
    }

    private void OnDisable()
    {
        // turn off the UI and clear the refence for it in this script so we can get a new one
        collection.ToggleUI();
        collection = null;
        TapUI = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(detect.InteractionoKey))
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
