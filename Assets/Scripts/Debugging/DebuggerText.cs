using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebuggerText : MonoBehaviour
{
    private Text text;

    public Image image;
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        if(this.gameObject.name == "Images")
        {
            if (image.sprite == null)
            {
                text.text = "Images 1: null";
            }
            else
            {
                text.text = "Images 1: " + image.sprite.name;
            }
        }

        if(this.gameObject.name == "Inventory")
        {
            NewInventory inventory = GameObject.Find("Player").GetComponent<NewInventory>();
            if(inventory.playerDrinks[0] == null)
            {
                text.text = "Inventory 1: null";
            }
            else
            {
                text.text = "Inventory 1: " + inventory.playerDrinks[0].drinks_SOs.name;
            }
        }

        if(this.gameObject.name == "Count")
        {
            NewInventory inventory = GameObject.Find("Player").GetComponent<NewInventory>();
            text.text = "Items in Inventory: " + inventory.itemInInventory;
        }
        
    }
}
