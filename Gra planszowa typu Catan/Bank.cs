using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    public int wood;
    public int brick;
    public int sheep;
    public int wheat;
    public int ore;

    public Text bankResources;

    void Update()
    {
        string temp;

        temp = " wood: " + wood + "\n";
        temp += " brick: " + brick + "\n";
        temp += " sheep: " + sheep + "\n";
        temp += " wheat: " + wheat + "\n";
        temp += " ore : " + ore;
        bankResources.text = temp;
    }
}
