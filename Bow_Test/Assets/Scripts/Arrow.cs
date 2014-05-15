using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour 
{
    public bool Loosed = false;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Loosed)
        {
            Quaternion rotation = Quaternion.LookRotation(rigidbody.velocity);
            transform.rotation = rotation;
        }
        
	}

    void OnTriggerEnter(Collider hit)
    {
        Debug.Log(hit.name);
        rigidbody.freezeRotation = true;
        rigidbody.velocity = Vector3.zero;
        rigidbody.useGravity = false;
        collider.enabled = false;
        Loosed = false;

    }
}
