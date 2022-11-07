using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomerScript : MonoBehaviour
{
    //this script is to be the central managing script for the customers

    public Customers customersSO;
    public List<Drinks_SO> drinksWanted;
    public int drinksNeeded;
    public bool isWaitng;

    private static float s_Speed;
    [Range(0f,1f)]
    public float p_Speed;

    private static int customerNumber = 1;


    [SerializeField]
    Vector2 targetPosition;
    private void Awake()
    {
        //load customer types and pick one randomly
        var customerTypes = Resources.LoadAll("ScriptableObjects/CustomerTypes", typeof(Customers));

        int randomIndex = 0;

        while (randomIndex != 2)
        {
            randomIndex = Random.Range(0, customerTypes.Length);
        }

        customersSO = (Customers)customerTypes[randomIndex];

        drinksNeeded = drinksWanted.Count;
        isWaitng = true;
        s_Speed = p_Speed;

    }
    
    //Function to update the number of drinks needed
    public int checkNumberOfDrinksNeeded()
    {
        int r = 0;

        foreach (Drinks_SO drinks in drinksWanted)
        {
            if(drinks != null)
            {
                r++;
            }
        }
        return r;
    }
    
    //Function to examine if the customer needs any more drinks
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

        //get the customer away & remove them from the list in the queue to allow others to take this space.
        gameObject.SetActive(false);

        QueueController queueScript = transform.parent.gameObject.GetComponent<QueueController>();

        //the customer served will always be at the front of the queue so just remove the first index element from the list.
        queueScript.inLine.RemoveAt(0);

        //then move the customers up one in the line for the list
        queueScript.MoveLineUp();
        
    }
    //Function to move the customer towards the preset target
    public void customerMove(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, s_Speed);
    }

    //function to assign a customer number based on the incrementing customerNumber int
    public string AssignCustomerName()
    {

        gameObject.name = "Customer Number " + customerNumber.ToString();
        string ret = gameObject.name;
        customerNumber++;
        //Debug.Log("Customer number is now: " + customerNumber);

        return ret;
    }
    
}
