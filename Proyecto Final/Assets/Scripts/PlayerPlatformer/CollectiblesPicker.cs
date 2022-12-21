using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectiblesPicker : MonoBehaviour, IData
{
    
    private bool Collected = false;
    public GameObject EffectCol;
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]

    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();

    }
    public void LoadData(GameData data)
    {
        data.CollectiblesCollected.TryGetValue(id, out Collected);
        if (Collected)
        {
            gameObject.SetActive(false);
        }
    }

    public void SaveData( ref GameData data)
    {
       

        if (data.CollectiblesCollected.ContainsKey(id))
        {
            data.CollectiblesCollected.Remove(id);
        }
        data.CollectiblesCollected.Add(id, Collected);
    }

   

    private void OnTriggerEnter(Collider coli)
    {
        if (coli.tag == "Player")
        {


            if (!Collected)
            {
                Instantiate(EffectCol, transform.position, transform.rotation);
                ShootPlatformer.soundManager.SeleccionAudio(5, 0.4f);

                Collect();
            }
        }

       
    }

    private void Collect()
    {
        Collected = true;
        gameObject.SetActive(false);
        GameEventsManager.instance.ColCollected();
       
    }
}
