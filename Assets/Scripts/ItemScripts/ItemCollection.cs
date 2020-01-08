﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{

    //public bool canInteract = false;

    [Tooltip("Assigns what drink you want to be able to collect from here")]
    public Drink drink;
   
    public enum Side {Top_Or_Down, Left_Or_Right }
    [Tooltip("Assigns which side of the drink collection you want the UI to appear on")]
    public Side side;


    [Range(-500, 500)]
    [Tooltip("Distance you want the UI element to be from the drink collection")]
    public float distance;

    [SerializeField]
    private GameObject linkedUI;

    public GameObject LinkedUI
    {
        get
        {
            return linkedUI;
        }
        set
        {
            linkedUI = value;
        }
    }
    private void Awake()
    {
        drink = GetComponent<Drink>();

        //warning to ensure the drink value is assigned
        if(drink == null)
        {
            Debug.LogError("Drink must be set to the drink component attached!", drink);
        }
    }

    public void ToggleUI()
    {
        Image[] images = linkedUI.GetComponentsInChildren<Image>();
        foreach (Image ims in images)
        {
            ims.enabled = !ims.enabled;
        }

    }
    

}
