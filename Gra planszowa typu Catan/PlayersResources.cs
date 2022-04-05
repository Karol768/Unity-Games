using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayersResources : MonoBehaviour
{
    public int[] wood; // 0 equal to player
    public int[] brick; // 0 equal to player
    public int[] sheep; // 0 equal to player
    public int[] wheat; // 0 equal to player
    public int[] ore; // 0 equal to player

    public int[] resourcesSum;

    public Text[] ai;

    public Text playerRes;

    public static bool give;

    public int[] tilesId;
    public string[] resourceOnTile;
    public int[] numberOnTile; 

    public int numberOfTiles;

    public GameObject dicesController;

    public int sum;

    public GameObject buildSystem;
    public GameObject bankSystem;
    public GameObject turnSystem;

    public int tileId;
    public string resource;
    public int whoseTurn;

    public Vector3[] waypointsNearToTiles;

    void Update()
    {
        for(int i=1; i<=3; i++)
        { 
            ai[i-1].text = "AI: " + i  + "     " + wood[i] + "       " + brick[i] + "       " + sheep[i] + "       " + wheat[i] + "       " + ore[i];
        }

        playerRes.text =  wood[0] + "        " + brick[0] + "        " + sheep[0] + "        " + wheat[0] + "        " + ore[0];

        if(give == true)
        {
            GiveResources();
            give = false;
        }

        sum = dicesController.GetComponent<ReadDices>().sum;

        for(int i=0; i<3; i++)
        {
            resourcesSum[i] = 0;
        }

        for(int i=0; i<3; i++)
        {
            resourcesSum[i] = wood[i] + brick[i] + sheep[i] + wheat[i] + ore[i];
        }
    }

    public void GiveResources()
    {
        tileId = 0;
        resource = "";
        int waypointId;

        if(sum != 7)
        for(int i=0; i<19; i++)
        {
            if(numberOnTile[i] == sum)
            {
                tileId = tilesId[i];
                resource = resourceOnTile[tileId];

                for(int j=0; j<3; j++) // j = player id
                {
                    waypointId = (int)waypointsNearToTiles[tileId * 2].x;
                    if(waypointId <99)
                    if(buildSystem.GetComponent<Build>().whoHasBuildingHere[waypointId] == "AI " + j)
                    {
                        if(resource == "wood")
                        {
                            wood[j] ++;
                            bankSystem.GetComponent<Bank>().wood --;
                        }
                        else if(resource == "brick")
                        {
                            brick[j] ++;
                            bankSystem.GetComponent<Bank>().brick --;
                        }
                        else if(resource == "sheep")
                        {
                            sheep[j] ++;
                            bankSystem.GetComponent<Bank>().sheep --;
                        }
                        else if(resource == "wheat")
                        {
                            wheat[j] ++;
                            bankSystem.GetComponent<Bank>().wheat --;
                        }
                        else if(resource == "ore")
                        {
                            ore[j] ++;
                            bankSystem.GetComponent<Bank>().ore --;
                        }
                    }
                    if(waypointId <99)
                    if(buildSystem.GetComponent<Build>().whoHasBuildingHere[waypointId] == "player" && j == 0)
                    {
                        if(resource == "wood")
                        {
                            wood[j] ++;
                            bankSystem.GetComponent<Bank>().wood --;
                        }
                        else if(resource == "brick")
                        {
                            brick[j] ++;
                            bankSystem.GetComponent<Bank>().brick --;
                        }
                        else if(resource == "sheep")
                        {
                            sheep[j] ++;
                            bankSystem.GetComponent<Bank>().sheep --;
                        }
                        else if(resource == "wheat")
                        {
                            wheat[j] ++;
                            bankSystem.GetComponent<Bank>().wheat --;
                        }
                        else if(resource == "ore")
                        {
                            ore[j] ++;
                            bankSystem.GetComponent<Bank>().ore --;
                        }
                    }

                    waypointId = (int)waypointsNearToTiles[tileId * 2].z;
                    if(waypointId <99)
                    if(buildSystem.GetComponent<Build>().whoHasBuildingHere[waypointId] == "AI " + j)
                    {
                        if(resource == "wood")
                        {
                            wood[j] ++;
                            bankSystem.GetComponent<Bank>().wood --;
                        }
                        else if(resource == "brick")
                        {
                            brick[j] ++;
                            bankSystem.GetComponent<Bank>().brick --;
                        }
                        else if(resource == "sheep")
                        {
                            sheep[j] ++;
                            bankSystem.GetComponent<Bank>().sheep --;
                        }
                        else if(resource == "wheat")
                        {
                            wheat[j] ++;
                            bankSystem.GetComponent<Bank>().wheat --;
                        }
                        else if(resource == "ore")
                        {
                            ore[j] ++;
                            bankSystem.GetComponent<Bank>().ore --;
                        }
                    }
                    if(waypointId <99)
                    if(buildSystem.GetComponent<Build>().whoHasBuildingHere[waypointId] == "player" && j == 0)
                    {
                        if(resource == "wood")
                        {
                            wood[j] ++;
                            bankSystem.GetComponent<Bank>().wood --;
                        }
                        else if(resource == "brick")
                        {
                            brick[j] ++;
                            bankSystem.GetComponent<Bank>().brick --;
                        }
                        else if(resource == "sheep")
                        {
                            sheep[j] ++;
                            bankSystem.GetComponent<Bank>().sheep --;
                        }
                        else if(resource == "wheat")
                        {
                            wheat[j] ++;
                            bankSystem.GetComponent<Bank>().wheat --;
                        }
                        else if(resource == "ore")
                        {
                            ore[j] ++;
                            bankSystem.GetComponent<Bank>().ore --;
                        }
                    }
                    waypointId = (int)waypointsNearToTiles[tileId * 2].y;
                    if(waypointId <99)
                    if(buildSystem.GetComponent<Build>().whoHasBuildingHere[waypointId] == "AI " + j)
                    {
                        if(resource == "wood")
                        {
                            wood[j] ++;
                            bankSystem.GetComponent<Bank>().wood --;
                        }
                        else if(resource == "brick")
                        {
                            brick[j] ++;
                            bankSystem.GetComponent<Bank>().brick --;
                        }
                        else if(resource == "sheep")
                        {
                            sheep[j] ++;
                            bankSystem.GetComponent<Bank>().sheep --;
                        }
                        else if(resource == "wheat")
                        {
                            wheat[j] ++;
                            bankSystem.GetComponent<Bank>().wheat --;
                        }
                        else if(resource == "ore")
                        {
                            ore[j] ++;
                            bankSystem.GetComponent<Bank>().ore --;
                        }
                    }
                    if(waypointId <99)
                    if(buildSystem.GetComponent<Build>().whoHasBuildingHere[waypointId] == "player" && j == 0)
                    {
                        if(resource == "wood")
                        {
                            wood[j] ++;
                            bankSystem.GetComponent<Bank>().wood --;
                        }
                        else if(resource == "brick")
                        {
                            brick[j] ++;
                            bankSystem.GetComponent<Bank>().brick --;
                        }
                        else if(resource == "sheep")
                        {
                            sheep[j] ++;
                            bankSystem.GetComponent<Bank>().sheep --;
                        }
                        else if(resource == "wheat")
                        {
                            wheat[j] ++;
                            bankSystem.GetComponent<Bank>().wheat --;
                        }
                        else if(resource == "ore")
                        {
                            ore[j] ++;
                            bankSystem.GetComponent<Bank>().ore --;
                        }
                    }

                    waypointId = (int)waypointsNearToTiles[tileId * 2 + 1].x;
                    if(waypointId <99)
                    if(buildSystem.GetComponent<Build>().whoHasBuildingHere[waypointId] == "AI " + j)
                    {
                        if(resource == "wood")
                        {
                            wood[j] ++;
                            bankSystem.GetComponent<Bank>().wood --;
                        }
                        else if(resource == "brick")
                        {
                            brick[j] ++;
                            bankSystem.GetComponent<Bank>().brick --;
                        }
                        else if(resource == "sheep")
                        {
                            sheep[j] ++;
                            bankSystem.GetComponent<Bank>().sheep --;
                        }
                        else if(resource == "wheat")
                        {
                            wheat[j] ++;
                            bankSystem.GetComponent<Bank>().wheat --;
                        }
                        else if(resource == "ore")
                        {
                            ore[j] ++;
                            bankSystem.GetComponent<Bank>().ore --;
                        }
                    }
                    if(waypointId <99)
                    if(buildSystem.GetComponent<Build>().whoHasBuildingHere[waypointId] == "player" && j == 0)
                    {
                        if(resource == "wood")
                        {
                            wood[j] ++;
                            bankSystem.GetComponent<Bank>().wood --;
                        }
                        else if(resource == "brick")
                        {
                            brick[j] ++;
                            bankSystem.GetComponent<Bank>().brick --;
                        }
                        else if(resource == "sheep")
                        {
                            sheep[j] ++;
                            bankSystem.GetComponent<Bank>().sheep --;
                        }
                        else if(resource == "wheat")
                        {
                            wheat[j] ++;
                            bankSystem.GetComponent<Bank>().wheat --;
                        }
                        else if(resource == "ore")
                        {
                            ore[j] ++;
                            bankSystem.GetComponent<Bank>().ore --;
                        }
                    }

                    waypointId = (int)waypointsNearToTiles[tileId * 2 + 1].z;
                    if(waypointId <99)
                    if(buildSystem.GetComponent<Build>().whoHasBuildingHere[waypointId] == "AI " + j)
                    {
                        if(resource == "wood")
                        {
                            wood[j] ++;
                            bankSystem.GetComponent<Bank>().wood --;
                        }
                        else if(resource == "brick")
                        {
                            brick[j] ++;
                            bankSystem.GetComponent<Bank>().brick --;
                        }
                        else if(resource == "sheep")
                        {
                            sheep[j] ++;
                            bankSystem.GetComponent<Bank>().sheep --;
                        }
                        else if(resource == "wheat")
                        {
                            wheat[j] ++;
                            bankSystem.GetComponent<Bank>().wheat --;
                        }
                        else if(resource == "ore")
                        {
                            ore[j] ++;
                            bankSystem.GetComponent<Bank>().ore --;
                        }
                    }
                    if(waypointId <99)
                    if(buildSystem.GetComponent<Build>().whoHasBuildingHere[waypointId] == "player" && j == 0)
                    {
                        if(resource == "wood")
                        {
                            wood[j] ++;
                            bankSystem.GetComponent<Bank>().wood --;
                        }
                        else if(resource == "brick")
                        {
                            brick[j] ++;
                            bankSystem.GetComponent<Bank>().brick --;
                        }
                        else if(resource == "sheep")
                        {
                            sheep[j] ++;
                            bankSystem.GetComponent<Bank>().sheep --;
                        }
                        else if(resource == "wheat")
                        {
                            wheat[j] ++;
                            bankSystem.GetComponent<Bank>().wheat --;
                        }
                        else if(resource == "ore")
                        {
                            ore[j] ++;
                            bankSystem.GetComponent<Bank>().ore --;
                        }
                    }

                    waypointId = (int)waypointsNearToTiles[tileId * 2 + 1].y;
                    if(waypointId <99)
                    if(buildSystem.GetComponent<Build>().whoHasBuildingHere[waypointId] == "AI " + j)
                    {
                        if(resource == "wood")
                        {
                            wood[j] ++;
                            bankSystem.GetComponent<Bank>().wood --;
                        }
                        else if(resource == "brick")
                        {
                            brick[j] ++;
                            bankSystem.GetComponent<Bank>().brick --;
                        }
                        else if(resource == "sheep")
                        {
                            sheep[j] ++;
                            bankSystem.GetComponent<Bank>().sheep --;
                        }
                        else if(resource == "wheat")
                        {
                            wheat[j] ++;
                            bankSystem.GetComponent<Bank>().wheat --;
                        }
                        else if(resource == "ore")
                        {
                            ore[j] ++;
                            bankSystem.GetComponent<Bank>().ore --;
                        }
                    }
                    if(waypointId <99)
                    if(buildSystem.GetComponent<Build>().whoHasBuildingHere[waypointId] == "player" && j == 0)
                    {
                        if(resource == "wood")
                        {
                            wood[j] ++;
                            bankSystem.GetComponent<Bank>().wood --;
                        }
                        else if(resource == "brick")
                        {
                            brick[j] ++;
                            bankSystem.GetComponent<Bank>().brick --;
                        }
                        else if(resource == "sheep")
                        {
                            sheep[j] ++;
                            bankSystem.GetComponent<Bank>().sheep --;
                        }
                        else if(resource == "wheat")
                        {
                            wheat[j] ++;
                            bankSystem.GetComponent<Bank>().wheat --;
                        }
                        else if(resource == "ore")
                        {
                            ore[j] ++;
                            bankSystem.GetComponent<Bank>().ore --;
                        }
                    }
                }
            }    
        }

        if(sum == 7)
        {
            for(int i=0; i<3; i++)
            {
                if(resourcesSum[i] >= 8)
                {
                    int x = 0;
                    x = resourcesSum[i] / 2;
                    while(x > 0)
                    {
                        int r = 0;
                        r = Random.Range(1, 6);

                        if(r == 1)
                        {
                            if(wood[i] > 0)
                            {
                                wood[i] --;
                                bankSystem.GetComponent<Bank>().wood ++;
                                x --;
                            }
                        }
                        else if(r == 2)
                        {
                            if(brick[i] > 0)
                            {
                                brick[i] --;
                                bankSystem.GetComponent<Bank>().brick ++;
                                x --;
                            }
                        }
                        else if(r == 3)
                        {
                            if(sheep[i] > 0)
                            {
                                sheep[i] --;
                                bankSystem.GetComponent<Bank>().sheep ++;
                                x --;
                            }
                        }
                        else if(r == 4)
                        {
                            if(wheat[i] > 0)
                            {
                                wheat[i] --;
                                bankSystem.GetComponent<Bank>().wheat ++;
                                x --;
                            }
                        }
                        else if(r == 5)
                        {
                            if(ore[i] > 0)
                            {
                                ore[i] --;
                                bankSystem.GetComponent<Bank>().ore ++;
                                x --;
                            }
                        }
                    }
                }
            }
        }
    }
}
