using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsCheck : MonoBehaviour
{

    private NewInventory inventory;

    private void Awake()
    {
        inventory = GetComponent<NewInventory>();
    }

    private void Start()
    {
        Debug.Log(inventory);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < inventory.inventoryCapacity; i++)
            {
                
            }
        }
    }
}
