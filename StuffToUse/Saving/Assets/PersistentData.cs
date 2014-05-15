using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersistentData : SingletonComponent<PersistentData> {

    int maxHealth = 100;
    public int MaxHealth
    {
        get { return maxHealth; }
    }

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

    List<Vector3> initialPositions;

    public void Save()
    {
        SaveData saveData = new SaveData(health,positions);
        SaveManager.Instance.Save(saveData);
    }
    public void Load()
    {
        SaveData saveData;

         if(!SaveManager.Instance.Load(out saveData))
         {
             Debug.Log("Save data does not exist");
             saveData = new SaveData(maxHealth, GenerateNewPositions());
         }
        health = saveData.Health;
        positions = saveData.Positions;
    }

    public List<float> GenerateNewPositions()
    {
        int numPos = 2;
        List<float> positions = new List<float>();
        for (int i = 0; i < numPos; i++)
        {
            float newPos = Random.value * 10f;
            positions.Add(newPos);
        }
        return positions;
    }


}
