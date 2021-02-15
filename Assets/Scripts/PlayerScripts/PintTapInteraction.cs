using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PintTapInteraction : MonoBehaviour
{

    private DetectRaycastObject detect;
    private NewInventory inventory;
    private ItemCollection collection;

    [SerializeField]
    private float timeOnTap;
    
    public GameObject TapUI;
    [SerializeField]
    private Image pintImage;
    [SerializeField]
    private Scrollbar scrollbar;

    [SerializeField]
    private float topUpSpeed;
    private void Awake()
    {
        //reference the Raycast script
        detect = GetComponent<DetectRaycastObject>();
        inventory = GetComponent<NewInventory>();
    }

    private void OnEnable()
    {
        //set or reset the timer back to 0
        timeOnTap = 0;
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
            pintImage = collection.LinkedUI.GetComponent<Image>();
            scrollbar = collection.LinkedUI.GetComponent<Scrollbar>();
            {
                if (pintImage == null)
                {
                    Debug.LogWarning("pint image is null");
                }
            }
            //collection.ToggleUI();
        }
    }

    private void OnDisable()
    {
        // turn off the UI and clear the refence for it in this script so we can get a new one
        if(timeOnTap > collection.TargetTime)
        {
            collection.ToggleUI();
        }
        collection = null;
        TapUI = null;
        timeOnTap = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(detect.InteractionoKey) && pintImage.enabled == false)
        {

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

        if (Input.GetKey(detect.InteractionoKey))
        {

            // this is when we are pouring the drink
            if (timeOnTap < collection.TargetTime && pintImage.enabled == false)
            {
                timeOnTap += Time.deltaTime;
                //add sound effects or some cue for progress...
            }

            if(timeOnTap >= collection.TargetTime)
            {
                if(pintImage.enabled == false)
                {
                    Debug.Log("UI is not enabled, turning on now...");
                    collection.ToggleUI();
                }
                //collection.ToggleUI();

                if(pintImage.enabled == true)
                {
                    //image is on and we can do the timed event
                    scrollbar.value += topUpSpeed;
                }
            }
        }
    }
}
