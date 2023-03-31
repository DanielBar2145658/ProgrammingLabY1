using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DataPersistentManager : MonoBehaviour
{
    public static DataPersistentManager manager;

    

    [SerializeField]
    string fileName;

    private SaveFileHandler fileHandler;
    private GameData gameData;

    PlayerMovement player;


    private void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        
        if (manager != null && manager != this)
        {
            Destroy(this);
            Debug.Log("Manager already exists in scene deleting the old one in the current scene");
        }
        else 
        {
            manager = this;
            Debug.Log("Manager doesnt exist new instance of manager used");
        }
           
    
    }

    // Start is called before the first frame update
    void Start()
    {
        string appPath = Application.persistentDataPath;
        string path = Path.Combine(appPath, fileName);

        fileHandler = new SaveFileHandler(path);

        Debug.Log(path);

        LoadGame();

        
    }

    public void LoadGame()
    {
        if (this.gameData == null)
        {
            NewGame();
        }

        this.gameData = fileHandler.Load();
    }

    public void SaveGame ()
    {
        fileHandler.Save(gameData, player);

    
    }

    public void NewGame() 
    {
        this.gameData = new GameData();
    }
    private void OnApplicationQuit()
    {
        SaveGame();
        Debug.Log("Saved Game");
    }
}
