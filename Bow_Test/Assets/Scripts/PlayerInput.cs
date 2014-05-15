using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour 
{
    CharacterController pc;
    private float speed = 0.4f;
	// Use this for initialization
	void Start () 
    {
        pc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (SixenseInput.Controllers[0].JoystickY >= 0.2f)
        {
            pc.Move(transform.forward * speed);
        }
        else if (SixenseInput.Controllers[0].JoystickY <= -0.2f)
        {
            pc.Move(transform.forward * speed * -1);
        }
	}
}
