using UnityEngine;
using System.Collections;

public class ArrowFactory : SingletonComponent<ArrowFactory>
{
    public GameObject arrowPrefab;

    public Arrow CraftArrow(ArrowTemplate arrowTemplate)
    {
        GameObject arrowObj = ObjectPool.Instance.GetPooledObject(arrowPrefab.name, false);
        Arrow arrow = arrowObj.GetComponent<Arrow>();
        
        Arrowhead _arrowHead;
        Arrow_Shaft _arrowShaft;
        Arrow_Fletching _arrowFletching;

        switch (arrowTemplate.ArrowHead)
        {
                
            case ItemDB.Arrowheads.Fire:
                _arrowHead = arrow.gameObject.AddComponent<Arrowhead_Fire>();
                arrow.arrowHead = _arrowHead;
                break;
            case ItemDB.Arrowheads.Ice:
                _arrowHead = arrow.gameObject.AddComponent<Arrowhead_Ice>();
                arrow.arrowHead = _arrowHead;
                break;
            default:
                break;
        }

        switch (arrowTemplate.ArrowShaft)
        {
            case ItemDB.ArrowShafts.Wood:
                _arrowShaft = arrow.gameObject.AddComponent<Arrow_Shaft_Wood>();
                arrow.arrowShaft = _arrowShaft;
                break;
            case ItemDB.ArrowShafts.Steel:
                _arrowShaft = arrow.gameObject.AddComponent<Arrow_Shaft_Steel>();
                arrow.arrowShaft = _arrowShaft;
                break;
            default:
                break;
        }

        switch (arrowTemplate.ArrowFletching)
        {
            case ItemDB.ArrowFletchings.Nylon:
                _arrowFletching = arrow.gameObject.AddComponent<Arrow_Fletching_Nylon>();
                arrow.arrowFletching = _arrowFletching;
                break;
            case ItemDB.ArrowFletchings.DragonWing:
                _arrowFletching = arrow.gameObject.AddComponent<Arrow_Fletching_DragonWing>();
                arrow.arrowFletching = _arrowFletching;
                break;
            default:
                break;
        }
        
        return arrow;
    }
}
