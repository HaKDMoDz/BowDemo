using UnityEngine;
using System.Collections;

public class ItemDB : SingletonComponent<ItemDB>
{

    public enum Arrowheads { Fire, Ice }
    public enum ArrowShafts { Wood, Steel }
    public enum ArrowFletchings { Nylon, DragonWing }



}
public class ArrowTemplate
{
    public bool CheckAllValuesSet()
    {
        return arrowHeadSet && arrowShaftSet && arrowFletchingSet;
    }

    bool arrowHeadSet = false;
    bool arrowShaftSet = false;
    bool arrowFletchingSet = false;

    ItemDB.Arrowheads arrowHead;

    public ItemDB.Arrowheads ArrowHead
    {
        get { return arrowHead; }
        set
        {
            arrowHead = value;
            arrowHeadSet = true;
            
        }
    }
    ItemDB.ArrowShafts arrowShaft;

    public ItemDB.ArrowShafts ArrowShaft
    {
        get { return arrowShaft; }
        set
        {
            arrowShaft = value;
            arrowShaftSet = true;
        }
    }
    ItemDB.ArrowFletchings arrowFletching;

    public ItemDB.ArrowFletchings ArrowFletching
    {
        get { return arrowFletching; }
        set
        {
            arrowFletching = value;
            arrowFletchingSet = true;
        }
    }
}
