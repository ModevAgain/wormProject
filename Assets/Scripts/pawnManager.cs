using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class pawnManager : NetworkBehaviour {

    public GameObject pawnObject;
    LevelOrganizer lvlOrg;
    public Dictionary<GameObject, GameObject> tilePawnMap;



	// Use this for initialization
	void Start () {
        
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void instantiatePawns(int teamFlag)
    {
        if (NetworkServer.active)
        {
            lvlOrg = GetComponent<LevelOrganizer>();
            int pawnMax = (int)lvlOrg.mapLength * 2;

            GameObject[,] map = lvlOrg.getMapInstance();

            Dictionary<GameObject, GameObject> tilePawnMap = new Dictionary<GameObject, GameObject>();

            int pawnCounter = 0;

            int firstRow;
            int secondRow;

            if (teamFlag == 1)
            {
                firstRow = 0;
                secondRow = 1;
            }
            else
            {
                firstRow = 6;
                secondRow = 7;
            }

            for (int i = 0; i < pawnMax; i++)
            {


                if (i < lvlOrg.mapLength)
                {
                    GameObject temp = Instantiate<GameObject>(pawnObject, map[firstRow, pawnCounter].transform.position, new Quaternion(0, 0, 0, 0));
                    NetworkServer.Spawn(temp);
                    temp.GetComponent<pawnScript>().setPawnMan(this);
                    temp.GetComponent<pawnScript>().setTeamFlag(teamFlag);
                    temp.GetComponent<pawnScript>().setCurrentTile(map[firstRow, pawnCounter].GetComponent<tileScript>());
                    tilePawnMap.Add(map[firstRow, pawnCounter], temp);
                    pawnCounter++;
                }
                else
                {
                    GameObject temp = Instantiate<GameObject>(pawnObject, map[secondRow, pawnCounter].transform.position, new Quaternion(0, 0, 0, 0));
                    NetworkServer.Spawn(temp);
                    temp.GetComponent<pawnScript>().setPawnMan(this);
                    temp.GetComponent<pawnScript>().setTeamFlag(teamFlag);
                    temp.GetComponent<pawnScript>().setCurrentTile(map[secondRow, pawnCounter].GetComponent<tileScript>());
                    tilePawnMap.Add(map[secondRow, pawnCounter], temp);
                    pawnCounter++;
                }

                if (pawnCounter == 8)
                {
                    pawnCounter = 0;
                }

            }
        }

        else instantiatePawns(teamFlag);

        
    }


    public enum attacks
    {
        ROCK,
        PAPER,
        SCISSORS
    }
}
