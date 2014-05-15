using UnityEngine;
using System.Collections;

public class meshdataDebug : MonoBehaviour 
{
    Mesh meshdata;
    Vector3 fromCentre;

	void Start () 
    {
        meshdata = gameObject.GetComponent<MeshFilter>().mesh;

        
	}
	
	// Update is called once per frame
	void Update () 
    {
        for (int i = 0; i < meshdata.vertices.Length; i++)
        {
            //meshdata.vertices[i] *= Mathf.Sin(Time.time) * 10f;
            meshdata.vertices[i].Scale(meshdata.vertices[i].normalized * Mathf.Sin(Time.time));
        }
        gameObject.GetComponent<MeshFilter>().mesh = meshdata;
        gameObject.GetComponent<MeshFilter>().mesh.RecalculateNormals();
	}
}
