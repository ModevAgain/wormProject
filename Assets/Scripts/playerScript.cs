using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerScript : MonoBehaviour {
    [SerializeField]
    GameObject currentTile;
    [SerializeField]
    ParticleSystem[] systems;

  
    float moveTimer = 0f;
    [SerializeField]
    float moveTime = 2f;

	// Use this for initialization
	void Start () {
        transform.position = currentTile.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        /* if (moveTimer > moveTime)
         {
             movement();
         }
         else moveTimer += 1 * Time.deltaTime;
         */ // OLD movement --> time based

        movement(); // action-based movement

        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach (ParticleSystem sys in systems)
            {
                sys.Play();
            }
        }
        
	}

    void movement()
    {

        

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveToNeighbour(direction.RIGHT);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveToNeighbour(direction.LEFT);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveToNeighbour(direction.TOP);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveToNeighbour(direction.BOTTOM);
        }
    }

    void movementOLD()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if(h > 0)
        {
            moveToNeighbour(direction.RIGHT);
        }
        if (h < 0)
        {
            moveToNeighbour(direction.LEFT);
        }
        if (v > 0)
        {
            moveToNeighbour(direction.TOP);
        }
        if (v < 0)
        {
            moveToNeighbour(direction.BOTTOM);
        }
    }

    void moveToNeighbour(direction dir)
    {
        switch (dir)
        {
            case direction.TOP: moveAction(currentTile.GetComponent<tileScript>().getNeighbour(direction.TOP));
                break;
            case direction.BOTTOM:
                moveAction(currentTile.GetComponent<tileScript>().getNeighbour(direction.BOTTOM));
                break;
            case direction.RIGHT:
                moveAction(currentTile.GetComponent<tileScript>().getNeighbour(direction.RIGHT));
                break;
            case direction.LEFT:
                moveAction(currentTile.GetComponent<tileScript>().getNeighbour(direction.LEFT));
                break;
        }
    }

    void moveAction(GameObject target)
    {
        Vector3 pos = transform.position;
        Vector3 tar = target.transform.position;     

        GetComponent<Rigidbody>().MovePosition(tar);
        

        currentTile = target;

        moveTimer = 0;
        
        
    }



    public enum direction
    {
        TOP,
        BOTTOM,
        RIGHT,
        LEFT,
    }
}
