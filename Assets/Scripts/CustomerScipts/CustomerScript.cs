using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{

    public Customers customersSO;
    public List<Drink_SO> drinksWanted;
    public int drinksNeeded;
    public bool isWaitng;

    private static float s_Speed;
    [Range(0f,1f)]
    public float p_Speed;

    [SerializeField]
    Vector2 targetPosition;
    private void Awake()
    {
        drinksNeeded = drinksWanted.Count;
        isWaitng = true;
        s_Speed = p_Speed;
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

    public void customerMove(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, s_Speed);
    }

    
}
