using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseScript : MonoBehaviour {

    bool selected = false;
    pawnScript selectedPawn;

    public bool readyForWalking = false;

    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {

        if(!selected)
        checkForMouseCollision();

        if (readyForWalking)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                checkForMouseCollisionWalking();
            }

        }
        }

    void checkForMouseCollision()
    {
        Ray mouseRay = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(mouseRay,out hit)){

            if(hit.collider.tag == "pawn")
            {
                //if (!Camera.main.GetComponent<HighlightsMultiple>().objectRenderers.Contains(hit.transform.GetComponent<Renderer>())){
                if (GetComponent<HighlightsMultiple>().containsOtherPawns())
                {
                    GetComponent<HighlightsMultiple>().objectRenderers.Add(hit.transform.GetComponent<Renderer>());
                    GetComponent<HighlightsMultiple>().enabled = true;
                }
                else if (!GetComponent<HighlightsMultiple>().objectRenderers.Contains(hit.transform.GetComponent<Renderer>()))
                {

                    GetComponent<HighlightsMultiple>().objectRenderers.Clear();
                    GetComponent<HighlightsMultiple>().objectRenderers.Add(hit.transform.GetComponent<Renderer>());
                    GetComponent<HighlightsMultiple>().enabled = true;
                }
               

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    selected = true;
                    hit.transform.GetComponent<pawnScript>().isSelected = true;
                    readyForWalking = true;
                    selectedPawn = hit.transform.GetComponent<pawnScript>();
                }

            }
            else if (!selected)
            {
                GetComponent<HighlightsMultiple>().objectRenderers.Clear();
            }
            else
            {
                GetComponent<HighlightsMultiple>().objectRenderers.Clear();
                GetComponent<HighlightsMultiple>().enabled = false;

            }

        }
        else if (!selected)
        {
            GetComponent<HighlightsMultiple>().objectRenderers.Clear();
        }
        else
        {
            GetComponent<HighlightsMultiple>().objectRenderers.Clear();
            GetComponent<HighlightsMultiple>().enabled = false;

        }



    }

    void checkForMouseCollisionWalking()
    {
        
        Ray mouseRay = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(mouseRay,out hit))
        {

            if (hit.transform.gameObject == selectedPawn.getCurrentTile().getNeighbour(playerScript.direction.TOP).gameObject)
            {
                selectedPawn.move(selectedPawn.getCurrentTile().getNeighbour(playerScript.direction.TOP).transform.position);
                selectedPawn.getCurrentTile().setTeamFlag(0);
                selectedPawn.setCurrentTile(selectedPawn.getCurrentTile().getNeighbour(playerScript.direction.TOP).GetComponent<tileScript>());
                selected = false;
                readyForWalking = false;
            }
            if (hit.transform.gameObject == selectedPawn.getCurrentTile().getNeighbour(playerScript.direction.BOTTOM).gameObject)
            {
                selectedPawn.move(selectedPawn.getCurrentTile().getNeighbour(playerScript.direction.BOTTOM).transform.position);
                selectedPawn.getCurrentTile().setTeamFlag(0);
                selectedPawn.setCurrentTile(selectedPawn.getCurrentTile().getNeighbour(playerScript.direction.BOTTOM).GetComponent<tileScript>());
                selected = false;
                readyForWalking = false;
            }
            if (hit.transform.gameObject == selectedPawn.getCurrentTile().getNeighbour(playerScript.direction.RIGHT).gameObject)
            {
                selectedPawn.move(selectedPawn.getCurrentTile().getNeighbour(playerScript.direction.RIGHT).transform.position);
                selectedPawn.getCurrentTile().setTeamFlag(0);
                selectedPawn.setCurrentTile(selectedPawn.getCurrentTile().getNeighbour(playerScript.direction.RIGHT).GetComponent<tileScript>());
                selected = false;
                readyForWalking = false;
            }
            if (hit.transform.gameObject == selectedPawn.getCurrentTile().getNeighbour(playerScript.direction.LEFT).gameObject)
            {
                selectedPawn.move(selectedPawn.getCurrentTile().getNeighbour(playerScript.direction.LEFT).transform.position);
                selectedPawn.getCurrentTile().setTeamFlag(0);
                selectedPawn.setCurrentTile(selectedPawn.getCurrentTile().getNeighbour(playerScript.direction.LEFT).GetComponent<tileScript>());
                selected = false;
                readyForWalking = false;
            }
        }

    }

    

}

