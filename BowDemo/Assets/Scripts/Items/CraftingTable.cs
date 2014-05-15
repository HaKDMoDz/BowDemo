using UnityEngine;
using System.Collections;

public class CraftingTable : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        if(col.name=="Player")
            CraftingSystem.Instance.DisplayCraftingInterface();
    }
    void OnTriggerExit(Collider col)
    {
        if (col.name == "Player")
            CraftingSystem.Instance.HideCraftingInterface();
    }
}
