using UnityEngine;
using System.Collections;

public class TimeKeeper : MonoBehaviour {

    float timeValue;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        timeValue = Mathf.Ceil(Time.time % 16);
        transform.renderer.material.SetFloat("_TimeValue", timeValue);
	}
}
