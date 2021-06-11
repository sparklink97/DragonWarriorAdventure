using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        text.text =  "Your score: " + PlayerPrefs.GetInt("PlayerScore");
    }
}
