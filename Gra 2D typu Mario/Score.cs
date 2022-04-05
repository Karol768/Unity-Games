using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    int amountGift;
    public TextMeshProUGUI scoreView; 

    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
    }

    public void IncrementScore()
    {
        amountGift ++;
        scoreView.text = amountGift.ToString ();
    }

    public void ResetScore()
    {
        amountGift = 0;
        scoreView.text = amountGift.ToString ();
    }

}
