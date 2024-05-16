using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class HighScoreSystem : MonoBehaviour
{
    private List<string> names = new List<string>();
    private List<float> scores = new List<float>();

    public TMP_Text textBox;
    
    void Start()
    {
       LoadScores();

        RefreshScoreDisplay();
    }

    public void RefreshScoreDisplay()
    {
       textBox.text = "";
       for (int index = 0; index < scores.Count ;index++)
       {
           textBox.text += names[index] + ": " + scores[index] + "\n";
       }
    }
    private void OnDestroy()
    {
        SaveScores();
    }

    public void LoadScores()
    {
        HighScoreData data = JsonSaveLoad.Load();
        if (data != null)
        {
            names = data.names.ToList();
            scores = data.scores.ToList();
        }
        else
        {
            names = new List<string>();
            scores = new List<float>();
        }
    }
    public void SaveScores()
    {
       HighScoreData data = new HighScoreData(scores.ToArray(), names.ToArray());
       JsonSaveLoad.Save(data);
    }
    
    public void NewScore(string name, float score)
    {
        for (int index = 0; index < scores.Count ;index++)
        {
            float highScore = scores[index];
            if (score > highScore)
            {
                scores.Insert(index, score);
                names.Insert(index, name);
                RefreshScoreDisplay();
                return;
            }
        }
        scores.Add(score);
        names.Add(name);
        RefreshScoreDisplay();
    }

}
