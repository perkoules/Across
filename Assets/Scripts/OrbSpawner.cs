using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    public GameObject orb;
    public Material[] orbMaterials;
    private CubeSpawner cubeSpawner;
    void Start()
    {
        StartCoroutine(InitialOrbSpawn());        
    }

    IEnumerator InitialOrbSpawn()
    {
        yield return new WaitForSeconds(5);
        cubeSpawner = FindObjectOfType<CubeSpawner>();
        cubeSpawner.floorTiles.RemoveAll(item => item == null);
        for (int i = 0; i < 10; i++)
        {
            int random = Random.Range(0, cubeSpawner.floorTiles.Count);
            GameObject orbClone = Instantiate(orb, cubeSpawner.floorTiles[random].transform.position + Vector3.down * 9.5f, Quaternion.identity);
            orbClone.GetComponent<MeshRenderer>().material = orbMaterials[0];
            if (i >= 5)
            {
                orbClone.GetComponent<MeshRenderer>().material = orbMaterials[1];
            }
        }
    }
}
