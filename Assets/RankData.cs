using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RankData
{
    public int rank;
    public int score;

    public RankData(int rank, int score)
    {
        this.rank = rank;
        this.score = score;
    }
}
