using UnityEngine;
using System.Collections;
using System;
using System.Linq;

//for easy inspector changes and persistence
[Serializable]
public class MovementProperties
{
    public float moveSpeed = 10f;
    public float decelerationTime = 0.2f;
    public float maxSpeed = 15f;
    public float jumpForce = 50f;
    public float maxSlope = 60f;

    public float horizontalLookSensitivity = 15f;
    public float verticalLookSensitivity = 15f;

    public float maxVerticalLookAngle = 60f;
    public float minVerticalLookAngle = -60f;
}


public class PlayerMove : MonoBehaviour
{
    public Camera playerCamera;
    public MovementProperties movementProperties;

    float currentVerticalAngle = 0f;
    float currentVelX;
    float currentVelZ;

    bool grounded = false;

    public void Move(float horizontal, float vertical)
    {
        //friction to slow down when not pressing any movement keys
        if (horizontal == 0.0f && vertical == 0.0f && grounded)
        {
            rigidbody.SetVelocityX(Mathf.SmoothDamp(rigidbody.velocity.x, 0.0f, ref currentVelX, movementProperties.decelerationTime));
            rigidbody.SetVelocityZ(Mathf.SmoothDamp(rigidbody.velocity.z, 0.0f, ref currentVelZ, movementProperties.decelerationTime));
        }
        
        {
            //making sure player doesn't keep accelerating past max speed
            Vector2 horizontalVelocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.z);

            if (horizontalVelocity.sqrMagnitude > (movementProperties.maxSpeed * movementProperties.maxSpeed))
            {
                horizontalVelocity.Normalize();
                horizontalVelocity *= movementProperties.maxSpeed;
            }
            rigidbody.SetVelocityX(horizontalVelocity.x);
            rigidbody.SetVelocityZ(horizontalVelocity.y);

            //this moves the player
            rigidbody.AddRelativeForce(horizontal * movementProperties.moveSpeed, 0f, vertical * movementProperties.moveSpeed);
        }
    }

    public void RotateLook(Vector2 turnDirection)
    {
        //player can rotate left and right
        if (Mathf.Abs(turnDirection.x) > 0.0f)
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
        //rigidbody.AddForce(transform.up * movementProperties.jumpForce);
        if(grounded)
            rigidbody.SetVelocityY(movementProperties.jumpForce);
    }

    void OnCollisionStay(Collision col)
    {
        //the player is grounded if any of contact points are at a lower slope than 60
        grounded = col.contacts
            .Any(contact => Vector3.Angle(contact.normal, Vector3.up) < movementProperties.maxSlope);
    }
    void OnCollisionExit()
    {
        grounded = false;
    }
}
