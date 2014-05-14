using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : SingletonComponent<PlayerInventory> {

    //inventory game objects are childed to this transform
    public Transform playerInvTrans;
    
    List<Arrow> arrows;
    
    bool showInventory = false;

    Rect inventoryWindowRect = new Rect(Screen.width - 250, 200, 200, 600);
    Rect invButtonRect;

    void Start()
    {
        arrows = new List<Arrow>();
        InputManager.Instance.OnKeyboardPress += KeyPress;
        invButtonRect = new Rect(10, 20, inventoryWindowRect.width - 20, 80);

    }

    void KeyPress(KeyboardEventArgs args)
    {
        if(args.key==KeyCode.I)
        {
            showInventory = true;
        }
        if(args.key==KeyCode.Escape)
        {
            showInventory = false;
        }
    }

    public void AddNewArrow(Arrow arrow)
    {
        arrows.Add(arrow);
        Transform arrowTrans = arrow.transform;
        arrowTrans.parent = playerInvTrans;
        arrowTrans.ResetTransform();
        arrow.gameObject.SetActive(false);
    }
    public Arrow GetFirstArrow()
    {
        if (arrows.Count > 0)
        {
            Arrow arrow = arrows[0];
            arrows.RemoveAt(0);
            arrow.transform.parent = null;
            arrow.gameObject.SetActive(true);
            return arrow;
        }
        else
            return null;
    }
    void OnGUI()
    {
        if(showInventory)
        {
            GUI.Window(0, inventoryWindowRect, InventoryWindowFunc, "Inventory");
        }
    }
    void InventoryWindowFunc(int windowID)
    {
        for (int i = 0; i < arrows.Count; i++)
        {
            if(GUI.Button(new Rect(invButtonRect.x, invButtonRect.y + i*invButtonRect.height, invButtonRect.width,invButtonRect.height), "Arrow:\n"+arrows[i].arrowHead.itemName+"\n" +arrows[i].arrowShaft.itemName +"\n" + arrows[i].arrowFletching.itemName))
            {
                 
            }
        }
    }
}
