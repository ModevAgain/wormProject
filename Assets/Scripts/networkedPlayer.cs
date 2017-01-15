using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class networkedPlayer : NetworkBehaviour {

    public GameObject cam;
    public int playerTeam = 0;

	// Use this for initialization
	void Start () {
        
        GameObject.FindGameObjectWithTag("GameController").GetComponent<pawnManager>().instantiatePawns(playerTeam);
        cam = Instantiate<GameObject>(cam,transform.position,transform.rotation);

        if (isLocalPlayer)
        {
            cam.SetActive(true);
        }

       GameObject[] pawns =  GameObject.FindGameObjectsWithTag("pawn");

        foreach (GameObject pawn in pawns)
        {
            if(pawn.GetComponent<pawnScript>().getTeamFlag() == playerTeam)
            {
                pawn.GetComponent<pawnScript>().owner = this;
            }
        }
        
        
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
