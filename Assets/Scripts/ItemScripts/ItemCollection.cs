using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{

    public bool canInteract = false;
    //public Drink_SO drink_SO;
    public Drink drink;
    //public int quality;


    private void Awake()
    {
        drink = GetComponent<Drink>();

        if(drink == null)
        {
            Debug.LogError("Drink must be set to the drink component attached!", drink);
        }
    }

}
