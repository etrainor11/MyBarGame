using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float turnSpeed;

    private Rigidbody2D rigidbody;

    private float xInput;
    private float yInput;

    private float angle;

    private Vector2 movement;
    private Vector2 rotation;

    

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        //Debug.Log("x: " + xInput);
        //Debug.Log("y: " + yInput);

        //rotation = new Vector2(xInput, 0);

        movement = transform.TransformDirection(new Vector3(0, yInput));

        angle -= xInput * turnSpeed;
        //Debug.Log(angle);
        rotation = new Vector2(angle, 0);
    }

    private void FixedUpdate()
    {
        movePlayer(movement);
        rotatePlayer();
    }

    void movePlayer(Vector2 direction)
    {
        rigidbody.MovePosition((Vector2)transform.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    void rotatePlayer()
    {
        //Quaternion q_rotate = Quaternion.Euler(rotation * Time.deltaTime * turnSpeed);
        rigidbody.MoveRotation(angle);
            
    }

}
