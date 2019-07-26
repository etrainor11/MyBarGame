using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public LearningTiles tiles;
    [SerializeField]
    private Vector2 targetPos;
    [SerializeField]
    private Vector2 startPos;
    public float moveSpeed;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        Debug.Log(tiles.availablePlaces.Count);

        targetPos = tiles.availablePlaces[Random.Range(0, tiles.availablePlaces.Count)];
        transform.position = targetPos;
        Debug.Log(transform.position + " is the players position currently");
    }

    // Update is called once per frame
    void Update()
    {
        GetNewTargetPosition();
        StartCoroutine(moveToTarget(targetPos));
    }

    void GetNewTargetPosition()
    {

        Vector3 currentPosition = transform.position;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            targetPos = new Vector3(currentPosition.x, currentPosition.y + 1, currentPosition.z);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            targetPos = new Vector3(currentPosition.x, currentPosition.y - 1, currentPosition.z);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetPos = new Vector3(currentPosition.x + 1, currentPosition.y, currentPosition.z);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetPos = new Vector3(currentPosition.x - 1, currentPosition.y, currentPosition.z);
        }

        
    
    }

    IEnumerator moveToTarget(Vector3 target)
    {

        startPos = transform.position;

        float distance = Vector3.Distance(startPos, target);
        Debug.Log(distance);

        while (distance > Mathf.Epsilon)
        {
            Debug.Log("moving");
            transform.position = Vector3.Lerp(startPos, target, moveSpeed * Time.deltaTime);
            yield return null;
        }

        
    }


   
    
}
