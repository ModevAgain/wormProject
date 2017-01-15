using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour {
    
    [Header("Neighbours")]
    [SerializeField]
    GameObject top;
    [SerializeField]
    GameObject bottom;
    [SerializeField]
    GameObject right;
    [SerializeField]
    GameObject left;

    [SerializeField]
    int teamFlag = 0;       // 1 for Team 1 , 2 for Team 2

    // Use this for initialization
    void Start () {
		
	}

    public void setNeighbours(GameObject t, GameObject b, GameObject r, GameObject l)
    {
        top = t;
        bottom = b;
        right = r;
        left = l;
    }

    public int getTeamFlag()
    {
        return teamFlag;
    }

    public void setTeamFlag(int team)
    {
        teamFlag = team;
    }

    public GameObject getNeighbour(playerScript.direction dir)
    {
        switch (dir)
        {
            case playerScript.direction.TOP:
                return top;
            case playerScript.direction.BOTTOM:
                return bottom;
            case playerScript.direction.RIGHT:
                return right;
            case playerScript.direction.LEFT:
                return left;
        }

        return null;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
