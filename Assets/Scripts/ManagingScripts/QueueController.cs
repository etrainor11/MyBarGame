using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> customers;

    [SerializeField]
    private List<GameObject> inLine;

    [SerializeField]
    private GameObject queueStartPoint;

    [SerializeField]
    private int queueLimit;

    [SerializeField]
    private List<Vector3> queuePositions;

    [SerializeField]
    private int currantQueueNumber;

    private Vector2 spawnPoint;
    [SerializeField]
    private float distance;
    private enum Direction { LeftToRight, RightToLeft, UpToDown, DownToUp };
    [SerializeField]
    private Direction direction;

    [SerializeField]
    private float speed;

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
                    target.y++;
                }
                break;
            case Direction.UpToDown:
                spawnPoint = new Vector2(queueStartPoint.transform.position.x, queueStartPoint.transform.position.y + distance);
                for (int i = 0; i < queueLimit; i++)
                {
                    queuePositions.Add(target);
                    target.y--;
                }
                break;
        }



    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnCustomer();
        MoveLineUp();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("spawn");
            SpawnCustomer();
            MoveLineUp();
        }
    }

    public void MoveLineUp()
    {
        for (int i = inLine.Count; i >= 0; i--)
        {
            if (i == 0)
            {
                StartCoroutine(MoveLine(queueStartPoint.transform.position, inLine[i]));
            }

            if(i > 0)
            {

            }
        }
    }

    void SpawnCustomer()
    {
        inLine.Add(Instantiate(customers[0], spawnPoint, Quaternion.identity, gameObject.transform));
    }

    IEnumerator MoveLine(Vector2 target, GameObject customer)
    {
        Vector2 startPosition = customer.transform.position;

        Debug.Log("target position: " + target);

        Debug.Log("start position: " + startPosition);

        Debug.Log("Distance:" + Vector2.Distance(customer.transform.position, target));

        CustomerScript customerScript = customer.GetComponent<CustomerScript>();

        while (Vector2.Distance(customer.transform.position, target) >= Mathf.Epsilon)
        {

            customerScript.customerMove(target);


            yield return null;
        }

        //Debug.Log("Reached the target!");
    }
}
