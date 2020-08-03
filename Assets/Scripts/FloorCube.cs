using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class FloorCube : MonoBehaviour
{
    public LayerMask layerMask;
    public Shader originalShader;
    public bool canBeStepped = false;
    private GameObject player;
    private Player playerScript;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex < 8)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerScript = player.GetComponent<Player>();
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex < 8)
        {
            if (player!= null && !Array.Exists(playerScript.colliders, col => col == this.GetComponent<Collider>()))
            {
                GetComponent<MeshRenderer>().material.shader = originalShader;
                canBeStepped = false;
            }
        }        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && this.gameObject.transform.parent.name.Contains("End"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
