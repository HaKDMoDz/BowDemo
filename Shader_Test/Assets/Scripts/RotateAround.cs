using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour 
{
    public Transform target;
    private float angle = 0;
    private float speed = 30;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
       
        angle = Time.deltaTime * speed;
        
        if (angle >= 360)
        {
            angle = 0;
        }

        transform.Rotate(transform.up, angle);
	}
}
