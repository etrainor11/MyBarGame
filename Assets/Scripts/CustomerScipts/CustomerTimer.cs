using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTimer : MonoBehaviour
{
    

    private float customerWaitingTime;

    public float CustomerWaitingTime
    {
        get { return customerWaitingTime; }
        set { customerWaitingTime = value; }
    }


    // Update is called once per frame
    void Update()
    {
        customerWaitingTime += Time.deltaTime;
    }
}
