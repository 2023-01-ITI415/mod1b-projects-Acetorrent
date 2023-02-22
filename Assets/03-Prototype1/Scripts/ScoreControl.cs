using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public SpawningScript difficulty;
    public Chase Chase;
    public EnemyMov Idle;
    public int difficultyScale = 1;

    // Start is called before the first frame update
    void Start()
    {
        Chase = FindObjectOfType<Chase>();
        Idle = FindObjectOfType<EnemyMov>();
        difficulty = FindObjectOfType<SpawningScript>();
        scoreText = GetComponent<Text>();

        score = 0;

        InvokeRepeating("UpdateScore", 3f, 1.0f);
        Invoke("increaseDifficulty", 3f);

    }

    // Update is called once per frame


    void UpdateScore()
    {
        
        score += 10;
        scoreText.text = "Score: " + score;

        
    }

    void increaseDifficulty()
    {
        if (score >= 10)
        {
            difficulty.increaseSpawn();
            difficultyScale++;
        }
        Invoke("increaseDifficulty", 3f);


    }

    public int getScore()
    {
        return score;
    }
    public float getDifficultyNum()
    {
        return (float)difficultyScale;
    }
}
