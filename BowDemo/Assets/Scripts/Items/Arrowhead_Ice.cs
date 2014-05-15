using UnityEngine;
using System.Collections;

public class Arrowhead_Ice : Arrowhead
{

    void Awake()
    {
        itemName = "Arrowhead: Ice";
    }
    public override void Collision(Collision col)
    {
        Debug.Log("Ice col");
    }
}
