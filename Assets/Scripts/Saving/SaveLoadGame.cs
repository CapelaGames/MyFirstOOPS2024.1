using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadGame : MonoBehaviour
{
    public void SaveGame()
    {
        HighScoreData data = new HighScoreData();
        JsonSaveLoad.Save(data);       
    }

    public void LoadGame()
    {
        
    }
}
