using UnityEngine;
using System.Collections;

public abstract class Arrow_Shaft:Item_Consumable {

    public float weight;
    public float durability;

    public virtual void Collision(Collision col)
    {

    }
}
