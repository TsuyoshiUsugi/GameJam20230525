using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class SCORE_MANAGER
{
    static public int Score { get; private set; } = 0;
    static public void AddScore(int score)
    {
        Score += score;
    }

}
