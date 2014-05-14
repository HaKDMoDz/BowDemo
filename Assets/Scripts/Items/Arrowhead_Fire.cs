using UnityEngine;
using System.Collections;

public class Arrowhead_Fire : Arrowhead
{
    void Awake()
    {
        itemName = "Arrowhead: Fire";
    }
    public override void Collision(Collision col)
    {
        Debug.Log("Fire col");
    }
}
