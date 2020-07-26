using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera cam;
    public LayerMask layerMask;
    public Collider[] colliders;
    public Shader originalShader, greenShader;

    private void FixedUpdate()
    {
        colliders = Physics.OverlapBox(transform.position, new Vector3(1.5f, 0.25f, 1.5f), Quaternion.identity, layerMask);        
        foreach (var col in colliders)
        {
            col.GetComponent<MeshRenderer>().material.shader = greenShader;
            col.gameObject.GetComponent<FloorCube>().canBeStepped = true;
        }
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 1000) && Input.GetKey(KeyCode.Mouse0) && hit.transform.gameObject.CompareTag("FloorCubeTag"))
        {
            if (hit.collider.gameObject.GetComponent<FloorCube>().canBeStepped)
            {
                transform.position = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("OrbTag"))
        {
            Destroy(other.gameObject);
            print("Orb Obtained");
        }
    }
}
