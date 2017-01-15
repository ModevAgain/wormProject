using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelOrganizer : MonoBehaviour {

    List<GameObject> tileList;
    
    GameObject[,] map;
    public float mapLength;

    // Use this for initialization
    void Start () {

        tileList = GameObject.FindGameObjectsWithTag("tile").ToList<GameObject>();
        
        mapLength = Mathf.Sqrt(tileList.Count);
        map = new GameObject[(int)mapLength,(int) mapLength];

        getTileOrderInMap();
        setupTileNeighbours();
        //GetComponent<pawnManager>().instantiatePawns();


    }

   public GameObject[,] getMapInstance()
    {
        return map;
    }

    void getTileOrderInMap()
    {

        int listLength = tileList.Count();
        ArrayList list = new ArrayList();

        for (int x = 0; x < listLength; x++)
        {
            GameObject tempTile = findLowestTile();
            list.Add(tempTile);
            tileList.Remove(tempTile);
        }

        int xCoord = 0;
        int yCoord = 0;

        for (int i = 0; i < list.Count; i++)
        {
            xCoord = getXCoordForMap(i);
            yCoord = getYCoordForMap(i, xCoord);
            map[xCoord, yCoord] = (GameObject)list[i];
            map[xCoord, yCoord].AddComponent<tileScript>();
        }          
    }

    void setupTileNeighbours()
    {
        for (int i = 0; i < mapLength; i++)
        {
            for (int j = 0; j < mapLength; j++)
            {
                

                GameObject top = null;
                GameObject bottom = null;
                GameObject right = null;
                GameObject left = null;

                if (i + 1 < mapLength && map[i + 1, j] != null)
                    top = map[i + 1, j];
                if (i - 1 >= 0 &&  map[i - 1, j] != null)
                    bottom = map[i - 1, j];
                if (j + 1 < mapLength && map[i, j + 1] != null)
                    right = map[i, j + 1];
                if (j % mapLength != 0 && map[i, j - 1] != null)
                    left = map[i, j - 1];

                map[i, j].GetComponent<tileScript>().setNeighbours(top, bottom, right, left);
            }
        }
    }

    int getXCoordForMap(int i)
    {
        return (int)(i / mapLength);
    }

    int getYCoordForMap(int i, int xCoord)
    {
        if(xCoord == 0)
        {
            return i;
        }
        return (int)(i - xCoord * mapLength);
    }

    GameObject findLowestTile()
    {
        coord lowestTileCoord = new coord(20, 20);
        GameObject lowestTile = null;

        foreach (GameObject tile in tileList)
        {
            coord tempCoord = new coord(tile.transform.position.x, tile.transform.position.z);
            

            if (tempCoord.isLowerThan(lowestTileCoord))
            {
                lowestTileCoord = tempCoord;
                lowestTile = tile;
            }
        }
        return lowestTile;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    struct coord
    {
        public coord(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public bool isLowerThan(coord other)
        {
            if (y < other.y)
                return true;

            else if (y == other.y)
            {
                if (x < other.x)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        float x;
        float y;
    }
}
