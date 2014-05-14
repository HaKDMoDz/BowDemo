using UnityEngine;
using System.Collections;

public class Arrow_Fletching_Nylon : Arrow_Fletching {
    void Awake()
    {
        itemName = "Fletching: Nylon";
    }
    public override void Collision(Collision col)
    {
        Debug.Log("Nylon col");
    }
}
