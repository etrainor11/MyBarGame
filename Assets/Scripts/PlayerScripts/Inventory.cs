using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int inventoryCapacity;

    public List<Drink> playerDrinks = new List<Drink>();
    public List<int> drinkQuality = new List<int>();

    [SerializeField]
    private List<Image> images;

    public int itemInInventory;

    private void Awake()
    {
        for (int i = 0; i < inventoryCapacity; i++)
        {
           playerDrinks.Add(null);
           drinkQuality.Add(0);
        }
    }

    public void AssignInventoryDisplay(int index)
    {
        if(playerDrinks[index] != null)
        {
            images[index].sprite = playerDrinks[index].drink_SOs.spriteImage;
            images[index].preserveAspect = true;
        }

        if(playerDrinks[index] == null)
        {
            images[index].sprite = null;
        }
    }


    
}
