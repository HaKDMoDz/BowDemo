using UnityEngine;
using System.Collections;
using System;

public class CraftingSystem : SingletonComponent<CraftingSystem>
{
    bool displayCraftingInterface = false;
    bool displayArrowheads = false;
    bool displayArrowShafts = false;
    bool displayArrowFletchings = false;

    string arrowheadName = "Arrowhead";
    string shaftName = "Shaft";
    string fletchingName = "Fletching";
    
    Rect craftingWindowRect = new Rect(Screen.width/2 - 250, Screen.height / 2-100, 500, 300);
    Rect buttonRect = new Rect(10, 20, 150, 50);
    //buttonRect = new Rect(craftingWindowRect.x + 10, craftingWindowRect.y + 10, 150, 50);

    ArrowTemplate arrowTemplate;
    void Start()
    {
        InputManager.Instance.OnKeyboardPress += KeyPress;
    }

    void KeyPress(KeyboardEventArgs args)
    {
        if (args.key == KeyCode.Escape)
            HideCraftingInterface();
    }

    public void DisplayCraftingInterface()
    {
        displayCraftingInterface = true;
        PlayerInput.Instance.canMove = false;
        arrowTemplate = new ArrowTemplate();

    }
    public void HideCraftingInterface()
    {
        displayCraftingInterface = false;
        PlayerInput.Instance.canMove = true;
    }

    
    void OnGUI()
    {
        if(displayCraftingInterface)
        {
            craftingWindowRect = GUI.Window(0, craftingWindowRect, CraftingWindowFunc, "Craft Arrow");
        }
    }

    void CraftingWindowFunc(int windowID)
    {

        if (GUI.Button(buttonRect,fletchingName))
        {
            displayArrowFletchings = true;
        }
        if(GUI.Button(new Rect(buttonRect.x+buttonRect.width+buttonRect.x,buttonRect.y, buttonRect.width,buttonRect.height),shaftName))
        {
            displayArrowShafts = true;
        }
        if(GUI.Button(new Rect(buttonRect.x+(buttonRect.width+buttonRect.x)*2,buttonRect.y,buttonRect.width,buttonRect.height),arrowheadName))
        {
            displayArrowheads=true;
        }
        if(GUI.Button(new Rect(craftingWindowRect.width/2 - 150, craftingWindowRect.height-30,100,30),"Craft"))
        {
            if (!arrowTemplate.CheckAllValuesSet())
            {
                Debug.Log("Cannot craft - not all components added");
            }
            else
            {
                Debug.Log("Crafting Arrow: " + arrowTemplate.ArrowHead.ToString() + arrowTemplate.ArrowFletching.ToString() + arrowTemplate.ArrowShaft.ToString());
                Arrow craftedArrow = ArrowFactory.Instance.CraftArrow(arrowTemplate);
                PlayerInventory.Instance.AddNewArrow(craftedArrow);
            }
        }

        if(GUI.Button(new Rect(craftingWindowRect.width/2 + 100, craftingWindowRect.height-30,100,30),"Exit"))
        {
            HideCraftingInterface();
        }

        if (displayArrowFletchings)
        {
            ItemDB.ArrowFletchings[] values = (ItemDB.ArrowFletchings[])Enum.GetValues(typeof(ItemDB.ArrowFletchings));
            for (int i = 0; i < values.Length; i++)
            {
                if (GUI.Button(new Rect(buttonRect.x, buttonRect.y + (i + 1) * buttonRect.height, buttonRect.width, buttonRect.height), values[i].ToString()))
                {
                    //Debug.Log(values[i].ToString() + "selected");
                    displayArrowFletchings = false;
                    fletchingName = values[i].ToString();
                    arrowTemplate.ArrowFletching = values[i];
                }
                
            }
        }
        if (displayArrowShafts)
        {
            ItemDB.ArrowShafts[] values = (ItemDB.ArrowShafts[])Enum.GetValues(typeof(ItemDB.ArrowShafts));
            for (int i = 0; i < values.Length; i++)
            {
                if (GUI.Button(new Rect(buttonRect.x + buttonRect.width + buttonRect.x, buttonRect.y + (i + 1) * buttonRect.height, buttonRect.width, buttonRect.height), values[i].ToString()))
                {
                    //Debug.Log(values[i].ToString() + "selected");
                    displayArrowShafts = false;
                    shaftName = values[i].ToString();
                    arrowTemplate.ArrowShaft = values[i];
                }
            }
        }


        if (displayArrowheads)
        {
            ItemDB.Arrowheads[] values = (ItemDB.Arrowheads[])Enum.GetValues(typeof(ItemDB.Arrowheads));
            //foreach (ItemDB.Arrowheads value in values)
            for (int i = 0; i < values.Length; i++)
            {
                
                if (GUI.Button(new Rect(buttonRect.x + (buttonRect.width + buttonRect.x) * 2, buttonRect.y + (i + 1) * buttonRect.height, buttonRect.width, buttonRect.height), values[i].ToString()))
                {
                    //Debug.Log(values[i].ToString() + "selected");
                    displayArrowheads = false;
                    arrowheadName = values[i].ToString();
                    arrowTemplate.ArrowHead = values[i];
                }
            }
        }
    }
}
