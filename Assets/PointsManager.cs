using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;
    public Text text;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

public void ChangeScore(int coinV)
    {
        score += coinV;
        text.text = "X " + score.ToString();
    }
}
