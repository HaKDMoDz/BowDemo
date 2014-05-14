using UnityEngine;
using System.Collections;
using System;

//for easy inspector changes and persistence
[Serializable]
public class MovementProperties
{
    public float moveSpeed = 10f;
    public float maxSpeed = 15f;
    public float horizontalLookSensitivity = 15f;
    public float verticalLookSensitivity = 15f;
    public float maxVerticalLookAngle = 60f;
    public float minVerticalLookAngle = -60f;
    public float jumpForce = 50f;
    
}


public class PlayerMove : MonoBehaviour
{
    public Camera playerCamera;
    public MovementProperties movementProperties;
    float currentVerticalAngle = 0f;

    public void Move(Vector2 direction)
    {
        //Vector3 newVel = Vector3.zero;
        //newVel += transform.forward * direction.y * movementProperties.moveSpeed*Time.deltaTime;
        //newVel += transform.right * direction.x * movementProperties.moveSpeed*Time.deltaTime;
        //rigidbody.velocity = newVel;
        
        //making sure player doesn't keep accelerating
        Vector2 horizontalVelocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.z);
        if (horizontalVelocity.magnitude > movementProperties.maxSpeed)
        {
            horizontalVelocity.Normalize();
            horizontalVelocity *= movementProperties.maxSpeed;
        }

        rigidbody.SetVelocityX(horizontalVelocity.x);
        rigidbody.SetVelocityZ(horizontalVelocity.y);


        //this moves the player
        rigidbody.AddRelativeForce(direction.x * movementProperties.moveSpeed, 0f, direction.y * movementProperties.moveSpeed);

    }
    
    public void RotateLook(Vector2 turnDirection)
    {
        //player can rotate left and right
        if(Mathf.Abs(turnDirection.x)>0.0f)
        {
            //rotate around Y axis to turn horizontally
            transform.RotateAroundYAxis(turnDirection.x * movementProperties.horizontalLookSensitivity);
        }

        //camera can look up and down
        if (Mathf.Abs(turnDirection.y) > 0.0f)
        {
            currentVerticalAngle += turnDirection.y * movementProperties.verticalLookSensitivity;
            currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, movementProperties.minVerticalLookAngle, movementProperties.maxVerticalLookAngle);
            playerCamera.transform.SetEulerX(-currentVerticalAngle);
        }
    }

    public void Jump()
    {
        Debug.Log("jump");
        rigidbody.AddForce(transform.up * movementProperties.jumpForce);
    }
    void Update()
    {
        //Debug.Log(rigidbody.velocity.magnitude);
    }
    
}
