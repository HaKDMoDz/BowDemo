using UnityEngine;
using System.Collections;

public class Arrow_Shaft_Steel : Arrow_Shaft {

    void Awake()
    {
        itemName = "Shaft: Steel";
    }
    public override void Collision(Collision col)
    {
        Debug.Log("Steel col");
    }
}
