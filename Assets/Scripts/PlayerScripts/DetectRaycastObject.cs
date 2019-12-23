using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRaycastObject : MonoBehaviour
{

    [SerializeField]
    private float interactionLength;

    [SerializeField]
    private LayerMask mask;

    private NewInventory inventory;

    private PintTapInteraction pintTapInteraction;

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
        pintTapInteraction = GetComponent<PintTapInteraction>();
    }

    void Start()
    {
        pintTapInteraction.enabled = false;
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
                pintTapInteraction.enabled = true;
            }

            if (hit2D.collider.tag == "Customer")
            {
                //do our customer interaction script here
            }
        }

        if(hit2D.collider == null)
        {
            //turn all the interactions off
            pintTapInteraction.enabled = false;
        }
    }
}
