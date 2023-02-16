using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreStoreHigh : MonoBehaviour
{
    public Text highScore;
    public int record = 150;
    public ScoreControl scoreManage;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreManage = FindObjectOfType<ScoreControl>();
        highScore = GetComponent<Text>();
        record = PlayerPrefs.GetInt("record", 150);
    }

    // Update is called once per frame
    void Update()
    {
        score = scoreManage.getScore();
        updateRecord();
        highScore.text = "High Score: " + record;
    }

    public void updateRecord()
    {
        if (score > record)
        {
            record = score;
            PlayerPrefs.SetInt("record", record);


        }
    }
}
