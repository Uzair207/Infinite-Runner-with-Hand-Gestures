using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environmentGenerator : MonoBehaviour
{

    // Use this for initialization
    public GameObject[] road;
    float zspawn = 0;
    float tileLength = 18;
    int numberOfTiles = 13;
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                spawnTile(0);
            }
            else
            {
                spawnTile(Random.Range(0, road.Length));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z -23 > zspawn - (numberOfTiles * tileLength))
        {
            spawnTile(Random.Range(0, road.Length));
            deleteTile();
        }
    }
    public void spawnTile(int index)
    {
        GameObject go=Instantiate(road[index], transform.forward * zspawn, transform.rotation);
        activeTiles.Add(go);
        zspawn += tileLength;
    }
    private void deleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
