using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IData
{
    
    [SerializeField] public int TotalCollectibles = 0;

    private int CurrentCollectibles = 0;
    private Text CollectiblesText;
    
    private void Awake()
    {
        CollectiblesText = this.GetComponent<Text>();
    }

    void Start()
    {                    
            GameEventsManager.instance.onColCollected += AddCollectible;
       
    }

    private void OnDestroy()
    {

        GameEventsManager.instance.onColCollected -= AddCollectible;
    }
    void Update()
    {
        CollectiblesText.text = "C O l l E C T I B L E S :  " + CurrentCollectibles +" / 40";
       
    }
    public void LoadData(GameData data)
    {
        foreach(KeyValuePair<string, bool> pair in data.CollectiblesCollected)
        {
            if (pair.Value)
            {
                CurrentCollectibles++;
            }
        }
    }

    public void SaveData(ref GameData data)
    {

    }
    public void AddCollectible()
    {
        
       CurrentCollectibles ++;
        
       
    }
}
