using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public LayerMask layerMask;
    public Collider[] colliders;
    public GameObject orb;
    public Shader originalShader, greenShader;
    private Camera cam;
    private AudioSource audioSource;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }
    private void FixedUpdate()
    {
        colliders = Physics.OverlapBox(transform.position, new Vector3(1.5f, 0.25f, 1.5f), Quaternion.identity, layerMask);
        foreach (var col in colliders)
        {
            if (!col.gameObject.transform.parent.gameObject.name.Contains("Start"))
            {
                col.GetComponent<MeshRenderer>().material.shader = greenShader;
                col.gameObject.GetComponent<FloorCube>().canBeStepped = true;
            }
            else
            {
                col.GetComponent<MeshRenderer>().material.shader = originalShader;
                col.gameObject.GetComponent<FloorCube>().canBeStepped = false;
            }
        }
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 5000) && hit.transform.gameObject.CompareTag("FloorCubeTag"))
        {
            if (Input.GetKey(KeyCode.Mouse0) && hit.collider.gameObject.GetComponent<FloorCube>().canBeStepped)
            {
                transform.position = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("OrbTag"))
        {
            audioSource.PlayOneShot(audioSource.clip);            
        }
    }
}
