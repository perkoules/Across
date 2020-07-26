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


    private void Update()
    {
        if (!Array.Exists(GameObject.FindObjectOfType<Player>().colliders, col => col == this.GetComponent<Collider>()))
        {
            GetComponent<MeshRenderer>().material.shader = originalShader;
            canBeStepped = false;
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
