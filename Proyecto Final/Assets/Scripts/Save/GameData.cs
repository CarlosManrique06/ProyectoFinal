using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameData
{
 
    public Vector3 playerPosition;

    public SerializableDictionary<string, bool> CollectiblesCollected;

    public GameData()
    {
        CollectiblesCollected = new SerializableDictionary<string, bool>();
        playerPosition = new Vector3(-4.25f, 9.02f, -4.67f);
    }
}
