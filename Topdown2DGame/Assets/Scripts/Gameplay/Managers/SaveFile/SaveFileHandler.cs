using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class SaveFileHandler
{
    string filePath = "";



    public SaveFileHandler(string path) 
    {
        filePath = path;
    }

    public GameData Load() 
    {
        GameData loadedGameData = null;
        if (File.Exists(filePath)) 
        {
            try
            {
                

                FileStream fs = new FileStream(filePath, FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                


                string dataPending = sr.ReadToEnd();

                loadedGameData = JsonUtility.FromJson<GameData>(dataPending);

                
                

                fs.Close();
                sr.Close();
            }

            catch (Exception e)
            {
                Debug.LogWarning($"Error occured when trying to load game data: {filePath} \n Exception: {e}");
            }


        }



        return loadedGameData;
    
    }

    public void Save(GameData gameData, PlayerMovement player) 
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            gameData.position = player.GetPlayerPosition();
            gameData.points = player.GetCoinAmount();


            string saveData = JsonUtility.ToJson(gameData, true);


            

            FileStream sr = new FileStream(filePath, FileMode.Create);
            StreamWriter sw = new StreamWriter(sr);

            sw.Write(saveData);

            sw.Close();
            sr.Close();

            
        }
        catch(Exception e)
            {
            Debug.LogWarning($"Error occured when trying to save game data: {filePath} \n Exception: {e}");
        }


    }
}
