using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public bool[] whoseTurn; // [0] equal to player
    public int id;

    public bool endTurn;

    public Text turnText;

    public bool firstStageDone;

    public int playersAfterFirstTurn;

    public bool firstTurn;

    public bool alreadyRoll;

    public Button rollButton; 

    public GameObject playerResources;
    public GameObject bank;

    void Start()
    {
        firstTurn = true;
        id = Random.Range(1,4);
        whoseTurn[id] = true;

        if(id != 0)
        {
            endTurn = true;
        }
    }

    void Update()
    {
        if(firstStageDone == false)
        {
            rollButton.interactable = false;
        }
        else if(whoseTurn[0] == true && alreadyRoll == false)
        {
            rollButton.interactable = true;            
        }
        else
        {
            rollButton.interactable = false;
        }

        if(endTurn == true && id != 0)
        {
            endTurn = false;
            StartCoroutine(Wait());
        }

        if(firstTurn == false)
        if(id == 0)
        {
            turnText.text = "Player Turn";
        }
        else
        {
            turnText.text = "AI " + id + " Turn";
        }

        if(firstTurn == true)
        {
            turnText.text = "Game Starts";
        }

        if(playersAfterFirstTurn == 4)
        {
            firstStageDone = true;
        }
    }

    public void ChangeTurn()
    {
        whoseTurn[id] = false;

        if(id <3)
        {
            //PlayAi();
            id++;
            PlayAi();
        }
        else
        {
            alreadyRoll = false;

            id = 0;
        }

        whoseTurn[id] = true;
    }

    public void EndYourTurn()
    {
        if(playersAfterFirstTurn < 4)
        {
            playersAfterFirstTurn++;
        }

        ChangeTurn();
    }

    public void PlayAi()
    {
        //StartCoroutine(Wait3());
        if(firstStageDone == false && id != 0)
        {
            Build.whichAiWantSettlement = id;
            StartCoroutine(Wait2());

            playersAfterFirstTurn ++;
        }
        else if(id != 0)
        {
            Dice1.roll = true;
            Dice2.roll = true;

            StartCoroutine(Wait3());

            ReadDices.d1 = true;
            ReadDices.d2 = true;

            if(playerResources.GetComponent<PlayersResources>().wood[id] >= 1 && playerResources.GetComponent<PlayersResources>().brick[id] >= 1 && playerResources.GetComponent<PlayersResources>().sheep[id] >= 1 && playerResources.GetComponent<PlayersResources>().wheat[id] >= 1)
            {
                playerResources.GetComponent<PlayersResources>().wood[id] --;
                playerResources.GetComponent<PlayersResources>().brick[id] --;
                playerResources.GetComponent<PlayersResources>().sheep[id] --;
                playerResources.GetComponent<PlayersResources>().wheat[id] --;

                bank.GetComponent<Bank>().wood ++;
                bank.GetComponent<Bank>().brick ++;
                bank.GetComponent<Bank>().sheep ++;
                bank.GetComponent<Bank>().wheat ++;

                Build.whichAiWantSettlement = id;
                StartCoroutine(Wait2());
            }

            StartCoroutine(Wait3());
        }
    }

    public void Roll()
    {
        alreadyRoll = true;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        ChangeTurn();
        yield return new WaitForSeconds(3f);
        endTurn = true;

        if(firstTurn == true)
        {
            firstTurn = false;
        }
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(1f);
        Build.whichAiWantSettlement = id;
    }

    IEnumerator Wait3()
    {
        yield return new WaitForSeconds(2f);
    }
}
