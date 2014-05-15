using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveData  {

    int health;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    List<float> positions;

    public List<float> Positions
    {
        get { return positions; }
        set { positions = value; }
    }

    public SaveData(int _health, List<float> _pos)
    {
        health = _health;
        positions = _pos;
    }
}
