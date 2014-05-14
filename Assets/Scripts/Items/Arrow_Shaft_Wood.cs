using UnityEngine;
using System.Collections;

public class Arrow_Shaft_Wood : Arrow_Shaft {

    void Awake()
    {
        itemName = "Shaft: Steel";
    }
    public override void Collision(Collision col)
    {
        Debug.Log("Wood col");
    }
}
