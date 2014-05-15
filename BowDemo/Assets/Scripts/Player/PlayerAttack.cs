using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    Arrow equippedArrow;

    public GameObject arrowPrefab;

    Transform trans;
    void Start()
    {
        trans = transform;
    }

    public void Shoot()
    {
        //GameObject arrowObj = ObjectPool.Instance.GetPooledObject(arrowPrefab.name, true);
        //GameObject arrow = Instantiate(arrowPrefab,trans.position+trans.forward, trans.rotation) as GameObject;
        //Arrow arrow = ArrowFactory.Instance.GetArrow(equippedArrow);
        //Arrow arrow = arrowObj.GetComponent<Arrow>();
        Arrow arrow = PlayerInventory.Instance.GetFirstArrow();
        if (arrow)
        {
            arrow.Init(trans.position + trans.forward, trans.rotation, 1.0f);
            arrow.rigidbody.AddForce(transform.forward * 2500f);
        }
        else
        {
            Debug.Log("out of arrows");
        }

    }

}
