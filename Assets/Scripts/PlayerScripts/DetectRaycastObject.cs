using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRaycastObject : MonoBehaviour
{
    //this class should serve only to detect what object we've hit then pass that info on to other classes to interact with 

    [SerializeField]
    private float interactionLength;

    [SerializeField]
    private LayerMask mask;

    private NewInventory inventory;

    private Interaction interaction;

    private RaycastHit2D hit2D;
    public RaycastHit2D Hit2D
    {
        get
        {
            return hit2D;
        }
    }

    [SerializeField]
    private KeyCode interactionKey;
    public KeyCode InteractionoKey
    {
        get
        {
            return interactionKey;
        }
    }
    private void Awake()
    {
        inventory = GetComponent<NewInventory>();
        interaction = GetComponent<Interaction>();
 
    }

    // Update is called once per frame
    void Update()
    {
        //creates a ray and draws it in the scene view
        hit2D = Physics2D.Raycast(transform.position, transform.up, interactionLength, mask);
        Debug.DrawRay(transform.position, transform.up * interactionLength, Color.green);

        //check if we hit something
        if(hit2D.collider != null)
        {
            if (hit2D.collider.tag == "DrinkStorage")
            {
                //do our pint script stuff here
                ItemCollection itemCollectionOnCollider = hit2D.collider.gameObject.GetComponent<ItemCollection>();
                Drink drink = hit2D.collider.gameObject.GetComponent<Drink>();
                //Debug.Log("Just hit the " + itemCollection.drink. + " object!");
                //Debug.Log(drink.drinks_SOs.DrinkName);
                interaction.enabled = true;
                interaction.itemCollection = itemCollectionOnCollider;
                interaction.objectCastingOn = hit2D.collider.gameObject;
                
            }

            if (hit2D.collider.tag == "Customer")
            {
                //do our customer interaction script here
                //Debug.Log("Just hit the " + hit2D.collider.gameObject.name + " object");
                interaction.enabled = true;
                interaction.objectCastingOn = hit2D.collider.gameObject;
            }
        }

        if(hit2D.collider == null)
        {
            //turn all the interactions off
            interaction.enabled = false;
        }
    }
}
