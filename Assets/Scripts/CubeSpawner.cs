using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public float spawnSpeed = 0.1f;
    public GameObject floorHolder;
    public GameObject prefabfloorCube;
    public List<GameObject> floorTiles;
    void Start()
    {
        StartCoroutine(SpawnTiles());
    }
    IEnumerator SpawnTiles()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (floorTiles.Count <= 100)
                {
                    floorTiles.Add(Instantiate(prefabfloorCube, new Vector3(0 + i * 1.5f, 10, 0 + j * 1.5f), Quaternion.Euler(0, 0, 0), floorHolder.transform));
                    yield return new WaitForSeconds(spawnSpeed);
                }
            }
        }        
    }
}
