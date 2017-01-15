using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class customNetworkManager : NetworkManager {

    int players = 0;
    [SerializeField]
    Transform startPos1;
    [SerializeField]
    Transform startPos2;

	// Use this for initialization
	void Start () {
		
	}

    override
    public void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        players += 1;

        GameObject player = null;

        if (players == 1)
        {
            player = (GameObject)GameObject.Instantiate(playerPrefab, startPos1.position, startPos1.rotation);
            player.GetComponent<networkedPlayer>().playerTeam = 1;
        }
        else
        {
            player = (GameObject)GameObject.Instantiate(playerPrefab, startPos2.position, startPos2.rotation);
            player.GetComponent<networkedPlayer>().playerTeam = 2;
        }
        
        
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
