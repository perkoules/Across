﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    private CubeSpawner cubeSpawner;
    public GameObject fire, point;
    public float speed = 5f, repeatRate = 6f;
    private GameObject fireProjectile;
    private Vector3 towards = Vector3.zero;
    void Start()
    {
        cubeSpawner = FindObjectOfType<CubeSpawner>();
        InvokeRepeating("Fire", 5, repeatRate);
    }

    void Fire()
    {
        cubeSpawner.floorTiles.RemoveAll(item => item == null);
        int random = Random.Range(0, cubeSpawner.floorTiles.Count);
        towards = cubeSpawner.floorTiles[random].transform.position;
        fireProjectile = Instantiate(fire, cubeSpawner.floorTiles[random].transform.position + Vector3.up * 10, Quaternion.identity);
    }

}
