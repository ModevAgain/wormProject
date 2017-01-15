using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawnScript : MonoBehaviour {

    [SerializeField]
    pawnManager.attacks attackType;
    [SerializeField]
    int teamFlag;
    [SerializeField]
    tileScript currentTile;

    public networkedPlayer owner;

    List<Renderer> pathTiles;

    public bool isSelected = false;

    pawnManager pawnMan;

	// Use this for initialization
	void Start () {

        
	}

    public void setPawnMan(pawnManager man)
    {
        pawnMan = man;
    }
    public void setTeamFlag(int team)
    {
        teamFlag = team;
    }
    public void setCurrentTile(tileScript tile)
    {
        currentTile = tile;
    }
    public tileScript getCurrentTile()
    {
        return currentTile;
    }
    public int getTeamFlag()
    {
        return teamFlag;
    }


    // Update is called once per frame
    void Update () {

        if (isSelected)
        {
            showPath();
        }

        if (currentTile.GetComponent<tileScript>().getTeamFlag() != teamFlag)

            currentTile.GetComponent<tileScript>().setTeamFlag(teamFlag);
        	
	}

    void showPath()
    {
        pathTiles = new List<Renderer>();

        Renderer[] rens = new Renderer[4];

        if (teamFlag != currentTile.getNeighbour(playerScript.direction.TOP).GetComponent<tileScript>().getTeamFlag())
        {
            if (!owner.cam.GetComponent<HighlightsMultiple>().objectRenderers.Contains(currentTile.getNeighbour(playerScript.direction.TOP).GetComponent<Renderer>()))
            {
                owner.cam.GetComponent<HighlightsMultiple>().objectRenderers.Add(currentTile.getNeighbour(playerScript.direction.TOP).GetComponent<Renderer>());
            }
        }
        if (teamFlag != currentTile.getNeighbour(playerScript.direction.BOTTOM).GetComponent<tileScript>().getTeamFlag())
        {
            if (!owner.cam.GetComponent<HighlightsMultiple>().objectRenderers.Contains(currentTile.getNeighbour(playerScript.direction.BOTTOM).GetComponent<Renderer>()))
            {
                owner.cam.GetComponent<HighlightsMultiple>().objectRenderers.Add(currentTile.getNeighbour(playerScript.direction.BOTTOM).GetComponent<Renderer>());
            }
        }
        if (teamFlag != currentTile.getNeighbour(playerScript.direction.RIGHT).GetComponent<tileScript>().getTeamFlag())
        {
            if (!owner.cam.GetComponent<HighlightsMultiple>().objectRenderers.Contains(currentTile.getNeighbour(playerScript.direction.RIGHT).GetComponent<Renderer>()))
            {
                owner.cam.GetComponent<HighlightsMultiple>().objectRenderers.Add(currentTile.getNeighbour(playerScript.direction.RIGHT).GetComponent<Renderer>());
            }
        }
        if (teamFlag != currentTile.getNeighbour(playerScript.direction.LEFT).GetComponent<tileScript>().getTeamFlag())
        {
            if (!owner.cam.GetComponent<HighlightsMultiple>().objectRenderers.Contains(currentTile.getNeighbour(playerScript.direction.LEFT).GetComponent<Renderer>()))
            {
                owner.cam.GetComponent<HighlightsMultiple>().objectRenderers.Add(currentTile.getNeighbour(playerScript.direction.LEFT).GetComponent<Renderer>());
            }
        }

        owner.cam.GetComponent<HighlightsMultiple>().enabled = true;

    }

    public void setAttackType(pawnManager.attacks type)
    {
        attackType = type;
    }

    public void move(Vector3 target) {

        //Vector3 dir = transform.position - target;

        //transform.Translate(dir);
        Debug.Log(target);
        transform.position = target;

        owner.cam.GetComponent<HighlightsMultiple>().objectRenderers.Clear();
        isSelected = false;
    }

   
}
