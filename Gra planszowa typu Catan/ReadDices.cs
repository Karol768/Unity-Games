using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadDices : MonoBehaviour
{
    public GameObject dice1;
    public GameObject dice2;
    public int dice1value;
    public int dice2value;
    public int sum;
    public static bool d1, d2;

    void Update()
    {
        dice1value = dice1.GetComponent<Dice1>().finalSide;
        dice2value = dice2.GetComponent<Dice2>().finalSide;

        sum = dice1value + dice2value;

        if(d1 == true && d2 == true)
        {
            PlayersResources.give = true;

            d1 = false;
            d2 = false;
        } 
    }
}
