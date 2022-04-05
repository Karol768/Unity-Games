using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int[] score; // 0 equal to player
    public Text[] aiText;
    public Text playerText;

    void Update()
    {
        for(int i = 1; i <= 3; i++)
        {
            aiText[i-1].text = "AI " + i + " Score: " + score[i];
        }

        playerText.text = "Player Score: " + score[0];
    }
}
