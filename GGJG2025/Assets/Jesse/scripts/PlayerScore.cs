using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{

    public int score
    {
        get;
        set;
    }

    public int bestScore
    {
        get;
        set;
    }

    private Vector3 startPosition;

    public void Awake()
    {

        startPosition = transform.position;
        bestScore = 0;
    }

    public void Update()
    {

        score = Mathf.RoundToInt(Mathf.Abs(transform.position.x - startPosition.x));
        bestScore = Mathf.Max(score, bestScore);
    }

    public void OnGameOver()
    {

        transform.position = startPosition;
    }

    public void OnGUI()
    {

        GUILayout.Label("Score: " + score.ToString());
        GUILayout.Label("Best Score: " + bestScore.ToString());
    }
}