using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    public GameObject orb;
    public Material orbMaterial;
    private CubeSpawner cubeSpawner;
    void Start()
    {
        StartCoroutine(SpawnOrbs());
        
    }

    IEnumerator SpawnOrbs()
    {
        yield return new WaitForSeconds(5);
        cubeSpawner = FindObjectOfType<CubeSpawner>();
        cubeSpawner.floorTiles.RemoveAll(item => item == null);
        for (int i = 0; i < 5; i++)
        {
            int random = Random.Range(0, cubeSpawner.floorTiles.Count);
            Instantiate(orb, cubeSpawner.floorTiles[random].transform.position + Vector3.down * 9.5f, Quaternion.identity);
        }
    }
}
