using UnityEngine;
using System.Collections;

public class Arrow : Projectile {

    public float weight;
    public float speed;
    public float durability;

    public Arrowhead arrowHead;
    public Arrow_Shaft arrowShaft;
    public Arrow_Fletching arrowFletching;

    Transform trans;
    Rigidbody _rigidbody;

    public delegate void Collided(Collision col);
    public event Collided OnCollision = new Collided(delegate(Collision col) { });

    void Awake()
    {
        trans = transform;
        _rigidbody = rigidbody;
        collider.enabled = false;
    }
    
    /// <summary>
    /// Called after instantiating from Object Pool
    /// </summary>
    public void Init(Vector3 spawnPos, Quaternion spawnRot, float destroyTimer)
    {
        trans.position = spawnPos;
        trans.rotation = spawnRot;
        collider.enabled = true;
        Invoke("ReturnToPool", destroyTimer);
    }
    public void ReturnToPool()
    {
        //remove all velocities from the arrow
        _rigidbody.ResetMovement();

        collider.enabled = false;

        //removing components to reset to a blank arrow
        Destroy(GetComponent<Arrowhead>());
        Destroy(GetComponent<Arrow_Shaft>());
        Destroy(GetComponent<Arrow_Fletching>());
        arrowHead = null;
        arrowShaft = null;
        arrowFletching = null;

        //return the object to the object pool
        ObjectPool.Instance.PoolObject(gameObject);
    }
    void OnCollisionEnter(Collision col)
    {
        OnCollision(col);
        arrowHead.Collision(col);
        arrowFletching.Collision(col);
        arrowShaft.Collision(col);
        //Debug.Log("arrow collision");
    }
    

}
