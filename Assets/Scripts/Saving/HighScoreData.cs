using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreData
{
    public float[] scores;
    public string[] names;
    public HighScoreData()
    {
        scores = new[] { 99f, 10f, 3f };
        names = new[] { "Andrew", "Adam", "Steve" };
    }

    public HighScoreData(float[] scores, string[] names)
    {
        this.scores = scores;
        this.names = names;
    }
}


[System.Serializable]
public class Float3
{
    public float x, y, z;

    public Float3(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }

    Vector3 ToVector()
    {
        return new Vector3(x, y, z);
    }
}