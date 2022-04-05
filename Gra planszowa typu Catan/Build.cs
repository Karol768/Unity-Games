using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Build : MonoBehaviour
{
    private SpriteRenderer rend;

    public Sprite settlement;
    public Sprite city;

    public bool buildProcedure;

    public GameObject[] spotButtons;
    public GameObject[] waypoints;

    public string[] whoHasBuildingHere;

    public int whereToPlace;

    public GameObject turnSystem;

    public bool alreadyBuild;

    public Color[] aiColors;

    public static int whichAiWantSettlement;

    public GameObject scoreSystem;

    public int numberOfPlayerSettlements;

    public Button placeButton;
    public Button endButton;

    public int toUpgrade;
    public GameObject playersResources;
    public GameObject upgradeWindow;

    void Start()
    {
        whereToPlace = 99;
        whichAiWantSettlement = 99;

        for(int i=0; i<24; i++)
        {
            whoHasBuildingHere[i] = "none";
        }

        for(int i=0; i<24; i++)
        {
            spotButtons[i].SetActive(false);
        }
    }

    void Update()
    {
        if(turnSystem.GetComponent<TurnSystem>().whoseTurn[0] == true)
        {
            placeButton.interactable = true;
            endButton.interactable = true;
        }
        else
        {
            placeButton.interactable = false;
            endButton.interactable = false;
        }

        if(buildProcedure == true)
        {
            for(int i=0; i<24; i++)
            {
                spotButtons[i].SetActive(true);
            }
        }
        else
        {
            for(int i=0; i<24; i++)
            {
                spotButtons[i].SetActive(false);
            }
        }

        if(whereToPlace != 99)
        {
            rend = waypoints[whereToPlace].GetComponent<SpriteRenderer>();
            rend.gameObject.transform.localScale = new Vector2(1f, 1f);
            rend.sprite = settlement;
            whoHasBuildingHere[whereToPlace] = "player";
            whereToPlace = 99;
            buildProcedure = false;

            scoreSystem.GetComponent<Score>().score[0] ++;
        }

        if(whichAiWantSettlement != 99)
        {
            bool procedure = true;
            int x = 0;

            while(procedure == true)
            {
                x = Random.Range(0, 24);

                if(whoHasBuildingHere[x] == "none")
                {
                    int id =0;
                    id = turnSystem.GetComponent<TurnSystem>().id;

                    whoHasBuildingHere[x] = "AI " + id;

                    scoreSystem.GetComponent<Score>().score[id] ++;

                    AiBuild(id, x);

                    procedure = false;
                    whichAiWantSettlement = 99;
                }
            }
        }
    }

    public void AiBuild(int playerId, int x)
    {
        whereToPlace = x;
        rend = waypoints[whereToPlace].GetComponent<SpriteRenderer>();
        rend.gameObject.transform.localScale = new Vector2(1f, 1f);
        rend.sprite = settlement;

        rend.color = aiColors[playerId - 1];

        whereToPlace = 99;
        buildProcedure = false;
    }

    public void BuildSettlement()
    {
        if(turnSystem.GetComponent<TurnSystem>().id == 0 && alreadyBuild == false && numberOfPlayerSettlements <2)
        buildProcedure = true;

        if(numberOfPlayerSettlements >= 2)
        {
            if(playersResources.GetComponent<PlayersResources>().wood[0] >= 1 && playersResources.GetComponent<PlayersResources>().brick[0] >= 1 
            && playersResources.GetComponent<PlayersResources>().sheep[0] >= 1 && playersResources.GetComponent<PlayersResources>().wheat[0] >= 1)
            {
                playersResources.GetComponent<PlayersResources>().wood[0] --;
                playersResources.GetComponent<PlayersResources>().brick[0] --;
                playersResources.GetComponent<PlayersResources>().sheep[0] --;
                playersResources.GetComponent<PlayersResources>().wheat[0] --;

                buildProcedure = true;
            }
        }
    }


    //SPOT FOR SETTLEMENTS BUTTONS

    public void SpotButton0() {whereToPlace = 0; numberOfPlayerSettlements++;}
    public void SpotButton1() {whereToPlace = 1; numberOfPlayerSettlements++;}
    public void SpotButton2() {whereToPlace = 2; numberOfPlayerSettlements++;}
    public void SpotButton3() {whereToPlace = 3; numberOfPlayerSettlements++;}
    public void SpotButton4() {whereToPlace = 4; numberOfPlayerSettlements++;}
    public void SpotButton5() {whereToPlace = 5; numberOfPlayerSettlements++;}
    public void SpotButton6() {whereToPlace = 6; numberOfPlayerSettlements++;}
    public void SpotButton7() {whereToPlace = 7; numberOfPlayerSettlements++;}
    public void SpotButton8() {whereToPlace = 8; numberOfPlayerSettlements++;}
    public void SpotButton9() {whereToPlace = 9; numberOfPlayerSettlements++;}
    public void SpotButton10() {whereToPlace = 10; numberOfPlayerSettlements++;}
    public void SpotButton11() {whereToPlace = 11; numberOfPlayerSettlements++;}
    public void SpotButton12() {whereToPlace = 12; numberOfPlayerSettlements++;}
    public void SpotButton13() {whereToPlace = 13; numberOfPlayerSettlements++;}
    public void SpotButton14() {whereToPlace = 14; numberOfPlayerSettlements++;}
    public void SpotButton15() {whereToPlace = 15; numberOfPlayerSettlements++;}
    public void SpotButton16() {whereToPlace = 16; numberOfPlayerSettlements++;}
    public void SpotButton17() {whereToPlace = 17; numberOfPlayerSettlements++;}
    public void SpotButton18() {whereToPlace = 18; numberOfPlayerSettlements++;}
    public void SpotButton19() {whereToPlace = 19; numberOfPlayerSettlements++;}
    public void SpotButton20() {whereToPlace = 20; numberOfPlayerSettlements++;}
    public void SpotButton21() {whereToPlace = 21; numberOfPlayerSettlements++;}
    public void SpotButton22() {whereToPlace = 22; numberOfPlayerSettlements++;}
    public void SpotButton23() {whereToPlace = 23; numberOfPlayerSettlements++;}

    public void Upgrade(int spotId)
    {
        if(playersResources.GetComponent<PlayersResources>().wheat[0] >= 2 && playersResources.GetComponent<PlayersResources>().ore[0] >= 3)
        {
            upgradeWindow.SetActive(true);
            toUpgrade = spotId;
        }
    }

    public void ExitUpgrade()
    {
        upgradeWindow.SetActive(false);
    }

    public void ConfirmUpgrade()
    {
        rend = waypoints[toUpgrade].GetComponent<SpriteRenderer>();
        rend.sprite = city;
        scoreSystem.GetComponent<Score>().score[0] ++;
        playersResources.GetComponent<PlayersResources>().wheat[0] -= 2;
        playersResources.GetComponent<PlayersResources>().ore[0] -= 3;
        upgradeWindow.SetActive(false);
    }

}
