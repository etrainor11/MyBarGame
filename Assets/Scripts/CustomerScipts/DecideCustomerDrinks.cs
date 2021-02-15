using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DecideCustomerDrinks
{
    //This script will look at customer types and select what drink 
    //they want from their associated drinks list 
    
    public List<Drinks_SO> DrinksCustomerWants(Customers customers)
    {
        string customerType = customers.drinks_SO.ToString();

        List<Drinks_SO> drinks = DrinksWantedDeterminedByType(customerType);
        return drinks;
    }

    private List<Drinks_SO> DrinksWantedDeterminedByType(string custType)
    {
        int drinksNumber = RandomNumberOfDrinks();
        List<Drinks_SO> drinksWanted = new List<Drinks_SO>(drinksNumber);

        List<Drinks_SO> acceptableDrinks = new List<Drinks_SO>();

        string[] paths = AssetDatabase.GetAllAssetPaths();

        switch (custType)
        {
            case "Beer Merchant":
                
                break;
            default:
                break;
        }

        return drinksWanted;
    }

    //randomised number for now
    private int RandomNumberOfDrinks()
    {
        int numberOfDrinksWanted = Random.Range(0, 4);

        return numberOfDrinksWanted;
    }
}
