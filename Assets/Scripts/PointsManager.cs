using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{

    public Text text;
    public int score;
    void Start()
    {
        score = PlayerPrefs.GetInt("PlayerScore");
        text.text = "X " + score.ToString();
        
    }
    private void Update()
    {
        score = PlayerPrefs.GetInt("PlayerScore");
    }
    public void ChangeScore(int value)
    {
        score += value;
        text.text = "X " + score.ToString();
        PlayerPrefs.SetInt("PlayerScore", score);
    }
}
