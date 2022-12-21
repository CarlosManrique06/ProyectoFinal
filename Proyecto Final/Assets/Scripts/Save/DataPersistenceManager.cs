using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("FIle Storage Config")]

    [SerializeField] private string fileName;

    private GameData gameData;
    private List<IData> dataPersistenceObjects;
    private FileData dataHandler;
    public static DataPersistenceManager instance {get;private set;}

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Found more than one");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileData(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPeristenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if(this.gameData == null)
        {
            Debug.Log("No data was found");
            NewGame();
        }

        foreach(IData dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IData dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
    }

   
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IData> FindAllDataPeristenceObjects()
    {
        IEnumerable<IData> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IData>();
        return new List<IData>(dataPersistenceObjects);
    }
}
