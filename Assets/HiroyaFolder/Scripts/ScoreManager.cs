using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class ScoreManager
{
    static public int Score { get; private set; } = 0;
    static public void AddScore(int score)
    {
        Score += score;
    }
    static public void RemoveScore()
    {
        Score = 0;
    }
}
