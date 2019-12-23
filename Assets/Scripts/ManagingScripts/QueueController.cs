using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QueueController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> customers;


    public List<GameObject> inLine;

    [SerializeField]
    private GameObject queueStartPoint;

    [SerializeField]
    private int queueLimit;

    [SerializeField]
    private List<Vector3> queuePositions;

    /*[SerializeField]
    private int currantQueueNumber;*/

    private Vector2 spawnPoint;
    [SerializeField]
    private float distance;
    private enum Direction { LeftToRight, RightToLeft, UpToDown, DownToUp };
    [SerializeField]
    private Direction direction;

    private void Awake()
    {
        float x_Position = transform.position.x;
        float y_Position = transform.position.y;

        Vector3 target = transform.position;

        //define direction line will move and accomidate starting point
        switch (direction)
        {
            case Direction.RightToLeft:
                spawnPoint = new Vector2(queueStartPoint.transform.position.x + distance, queueStartPoint.transform.position.y);
                for (int i = 0; i < queueLimit; i++)
                {
                    queuePositions.Add(target);
                    target.x++;
                }
                break;
            case Direction.LeftToRight:
                spawnPoint = new Vector2(queueStartPoint.transform.position.x - distance, queueStartPoint.transform.position.y);
                for (int i = 0; i < queueLimit; i++)
                {
                    queuePositions.Add(target);
                    target.x--;
                }
                break;
            case Direction.DownToUp:
                spawnPoint = new Vector2(queueStartPoint.transform.position.x, queueStartPoint.transform.position.y - distance);
                for (int i = 0; i < queueLimit; i++)
                {
                    queuePositions.Add(target);
                    target.y--;
                }
                break;
            case Direction.UpToDown:
                spawnPoint = new Vector2(queueStartPoint.transform.position.x, queueStartPoint.transform.position.y + distance);
                for (int i = 0; i < queueLimit; i++)
                {
                    queuePositions.Add(target);
                    target.y++;
                }
                break;
        }



    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnCustomer();
    }

    // Update is called once per frame
    void Update()
    {
        //to use to simulate new customers entering
        if(inLine.Count < queueLimit)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                SpawnCustomer();
            }
        }
        

        MoveLineUp();
    }

    public void MoveLineUp()
    {
        for (int i = 0; i <= inLine.Count - 1; i++)
        {
            //Debug.Log("MoveLineUp iteration = " + i);
            if(Vector3.Distance(inLine[i].transform.position, queuePositions[i]) > Mathf.Epsilon)
            {
                CustomerScript customerScript = inLine[i].GetComponent<CustomerScript>();
                customerScript.customerMove(queuePositions[i]);
            }
        }
    }

    void SpawnCustomer()
    {
        //instantiate customer and obtain a reference of there customerscript
        inLine.Add(Instantiate(customers[0], spawnPoint, Quaternion.identity, gameObject.transform));
        GameObject newCustomer = GameObject.Find("Customer(Clone)");
        CustomerScript customerScript = newCustomer.GetComponent<CustomerScript>();
        
        //change the name of the customer
        customerScript.AssignCustomerName();
       
    }
}
