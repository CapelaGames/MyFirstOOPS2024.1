using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreSystem : MonoBehaviour
{
    //Highest to lowest
    private List<string> names = new List<string>();
    private List<float> scores = new List<float>();
    void Start()
    {
       NewScore("test10",10f); 
       NewScore("test4",4f); 
       NewScore("test8",8f); 
       NewScore("test8b",8f); 
       NewScore("test3",3f); 
       NewScore("test11",11f); 
       NewScore("test2",2f);

       foreach (var score in scores)
       {
           Debug.Log(score );
       }
       foreach (var name in names)
       {
           Debug.Log(name );
       }

       HighScoreData data = new HighScoreData(scores.ToArray(), names.ToArray());
       JsonSaveLoad.Save(data);
    }
    public void NewScore(string name, float score)
    {
        for(int index = 0; index < scores.Count ; index ++)
        {
            float highScore = scores[index];
            if (score > highScore)
            {
               scores.Insert(index, score); 
               names.Insert(index, name);
               return;
            }
        } 
        scores.Add(score); 
        names.Add(name);
    }
}
