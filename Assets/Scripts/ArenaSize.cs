using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaSize : MonoBehaviour
{
    public static ArenaSize instance;

    public bool rescaleWithScore = false;
    public float ArenaRadius => arenaRadius;
    float arenaRadius;

    [SerializeField] float arenaRadiusBase = 7f;
    [SerializeField] float arenaRadiusPerMultiplier = 1.5f;
    [SerializeField] float arenaResizeSpeed = 5f;
    float TargetArenaRadius => arenaRadiusBase + arenaRadiusPerMultiplier * currentScoreMultiplier;
    float ArenaSizeDifference => TargetArenaRadius - arenaRadius;

    [SerializeField] Transform arena;

    float currentScoreMultiplier = 1;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Score.onScoreMultiplierChanged += ScoreMultiplierChanged;

        arenaRadius = arenaRadiusBase + arenaRadiusPerMultiplier * currentScoreMultiplier;
        arena.localScale = new Vector3(arenaRadius * 2, 1, arenaRadius * 2);
    }

    private void Update()
    {
        if (rescaleWithScore) RescaleArena();
    }

    private void OnDestroy()
    {
        Score.onScoreMultiplierChanged -= ScoreMultiplierChanged;
    }

    void RescaleArena()
    {
        if(Mathf.Abs(ArenaSizeDifference) >= 0.1f)
        {
            arenaRadius += ArenaSizeDifference * arenaResizeSpeed * Time.deltaTime / Mathf.Abs(ArenaSizeDifference);

            arena.localScale = new Vector3(arenaRadius * 2, 1, arenaRadius * 2);
        }
    }

    void ScoreMultiplierChanged(int value)
    {
        currentScoreMultiplier = value;
    }
}
