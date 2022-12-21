using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

   

    public event Action onColCollected;
    public void ColCollected() 
    {
        if (onColCollected != null) 
        {
            onColCollected();
        }
    }
}
