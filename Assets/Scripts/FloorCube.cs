using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FloorCube : MonoBehaviour
{
    //private Animation anim;
    public LayerMask layerMask;
    public Shader originalShader;
    public bool canBeStepped = false;

    private void Start()
    {
       //anim = GetComponent<Animation>();
    }

    private void Update()
    {
        if (!Array.Exists(GameObject.FindObjectOfType<Player>().colliders, col => col == this.GetComponent<Collider>()))
        {
            GetComponent<MeshRenderer>().material.shader = originalShader;
            canBeStepped = false;
        }
        
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.name == "Lava"))
        {
            anim.Play("Anim_FloorTile");
        }
    }*/
}
