using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{

    public Customers customersSO;
    public List<Drink_SO> drinksWanted;
    public int drinksNeeded;
    public bool isWaitng;

    private void Awake()
    {
        drinksNeeded = drinksWanted.Count;
        isWaitng = true;
    }

    public int checkNumberOfDrinksNeeded()
    {
        int r = 0;

        foreach (Drink_SO drinks in drinksWanted)
        {
            if(drinks != null)
            {
                r++;
            }
        }
        return r;
    }

    public bool checkIfCustomerIsDone (int drinksLeft)
    {
        bool stillWaiting;

        if(drinksLeft > 0)
        {
            stillWaiting = true;
        }
        else
        {
            stillWaiting = false;
        }

        return stillWaiting;
    }

    public void customerLeave()
    {
        //get the customer away - for now just disable
        gameObject.SetActive(false);
    }
    
}
