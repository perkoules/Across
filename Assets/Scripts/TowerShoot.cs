using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerShoot : MonoBehaviour
{
    private CubeSpawner cubeSpawner;
    public GameObject fire, point;
    private GameObject fireProjectile;
    private Vector3 towards = Vector3.zero;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex < 8)
        {
            cubeSpawner = FindObjectOfType<CubeSpawner>();
            InvokeRepeating("Fire", 5, Random.Range(2.5f, 4));
        }        
    }

    void Fire()
    {
        cubeSpawner.floorTiles.RemoveAll(item => item == null);
        int random = Random.Range(0, cubeSpawner.floorTiles.Count);
        towards = cubeSpawner.floorTiles[random].transform.position;
        fireProjectile = Instantiate(fire, cubeSpawner.floorTiles[random].transform.position + Vector3.up * 10, Quaternion.identity);
    }

}
