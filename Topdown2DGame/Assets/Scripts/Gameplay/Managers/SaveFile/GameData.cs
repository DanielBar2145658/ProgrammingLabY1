using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    public int kills;
    public int points;

    public Vector2 position;


    public GameData() 
    {
        this.points = 0;
        this.kills = 0;

        this.position = new Vector2(0,0);
    
    }
}
