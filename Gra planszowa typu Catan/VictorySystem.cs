using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictorySystem : MonoBehaviour
{
    public GameObject scoreSystem;

    public Text victoryText;

    public string[] players; // 0 equal to player

    public GameObject victoryWindow;

    void Update()
    {
        for(int i =0; i<4; i++)
        {
            if(scoreSystem.GetComponent<Score>().score[i] >= 10)
            {
                Victory(i);
            }
        }
    }

    private void Victory(int x)
    {
        victoryText.text = "Victory!!! : " + players[x]; 
        victoryWindow.SetActive(true);
    }
}
