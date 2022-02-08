using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    private float zSpawn = 0;
    private float tileLengh = 60;
    private float lastPosZ;
    private List<GameObject> tileActive;

    void Start()
    {
        tileActive = new List<GameObject>();
        tileSpawn(8);
        tileSpawn(Random.Range(0, 8));
    }

    
    void Update()
    {
        if (transform.position.z >= (lastPosZ + 60))
        {
            lastPosZ = transform.position.z;
            tileSpawn(Random.Range(0, 8));
            tileDelete();
        }
    }
    public void tileSpawn(int indexTile)
    {
        tileActive.Add((GameObject)Instantiate(tilePrefabs[indexTile], transform.forward * zSpawn, transform.rotation));
        zSpawn += tileLengh;
    }
    public void tileDelete()
    {
        if (tileActive.Count >= 4)
        {
            Destroy(tileActive[0]);
            tileActive.RemoveAt(0);
        }
    }
}
