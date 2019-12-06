using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewInventory : MonoBehaviour
{
    public int inventoryCapacity;

    public List<Drink> playerDrinks = new List<Drink>();
    public List<int> drinkQuality = new List<int>();

    [SerializeField]
    private List<Image> images;

    public int itemInInventory;

    private void Awake()
    {
        //set the inventory to null and the quality to 0 at the start of the level
        for (int i = 0; i < inventoryCapacity; i++)
        {
            playerDrinks.Add(null);
            drinkQuality.Add(0);
        }
    }

    public void AssignInventoryDisplayer(int index)
    {
        if (playerDrinks[index] != null)
        {
            images[index].sprite = playerDrinks[index].drinks_SOs.spriteImage;
            images[index].preserveAspect = true;
        }

        if (playerDrinks[index] == null)
        {
            images[index].sprite = null;

        }
    }

    //funation used to update the inventory UI to show what player has in inventory
    public void NewAssignToDisplay(int index)
    {
        if (playerDrinks[index] != null)
        {
            //Debug.Log(images[index].color);

            images[index].sprite = playerDrinks[index].drinks_SOs.spriteImage;
            images[index].preserveAspect = true;
        }

        if (playerDrinks[index] == null)
        {
            images[index].sprite = null;

        }
    }

    //in case you need a text to see what you got in the inventory
    public void ListInventoryItems()
    {
        foreach (Drink drink in playerDrinks)
        {
            if(drink == null)
            {

            }

            else
            {
                Debug.Log(drink.drinks_SOs.DrinkName);
            }
        }
    }
}
