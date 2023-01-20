using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardScoreOnKill : MonoBehaviour
{
    public delegate void AwardScoreDelegate(int value);
    public static AwardScoreDelegate onAwardScore;

    [SerializeField] int scoreAward;

    private void OnDestroy()
    {
        if (onAwardScore != null) onAwardScore(scoreAward);
        
    }
}
