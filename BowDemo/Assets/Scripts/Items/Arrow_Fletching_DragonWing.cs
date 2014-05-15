using UnityEngine;
using System.Collections;

public class Arrow_Fletching_DragonWing : Arrow_Fletching
{
    
    void Awake()
    {
        itemName = "Fletching: DragonWing";
    }

    public override void Collision(Collision col)
    {
        Debug.Log("Dragon wing col");
    }
	
}
