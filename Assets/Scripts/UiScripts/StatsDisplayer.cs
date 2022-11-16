using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplayer : MonoBehaviour
{

    [SerializeField]
    private Text customerNumberText;

    private int customersSpawned = 0;

   public void IncrementCustomerAmount()
    {
        LevelStats levelStats = GameObject.Find("Manager").GetComponent<LevelStats>();
        if (levelStats == null)
        {
            Debug.LogError("Level Stats is null");
            return;
        }
        levelStats.TotalCustomersSpawned++;
        customersSpawned = levelStats.TotalCustomersSpawned;
        UpdateCustomerAmountText();
    }

    private void UpdateCustomerAmountText()
    {
        customerNumberText.text = $"Customers spawned: {customersSpawned}";
    }

    private void Awake()
    {
        UpdateCustomerAmountText();
    }
}
