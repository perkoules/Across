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
    private int[] orbsObtained = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
    private int totalOrbs = 0;
    private AudioSource audioSource;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        InitializeCollectedOrbs();
    }

    private void InitializeCollectedOrbs()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerPrefs.SetInt("Red", 0);
            PlayerPrefs.SetInt("Orange", 0);
            PlayerPrefs.SetInt("Yellow", 0);
            PlayerPrefs.SetInt("Green", 0);
            PlayerPrefs.SetInt("Blue", 0);
            PlayerPrefs.SetInt("Indigo", 0);
            PlayerPrefs.SetInt("Violet", 0);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            totalOrbs = orbsObtained[0] + orbsObtained[1] + orbsObtained[2] + orbsObtained[3] + orbsObtained[4] + orbsObtained[5] + orbsObtained[6];
            if (totalOrbs == 70)
            {
                GameObject.FindGameObjectWithTag("EndTextTag").GetComponent<Text>().text = $"You Won! Orbs Collected: {totalOrbs}/70";
            }
            else
            {
                GameObject.FindGameObjectWithTag("EndTextTag").GetComponent<Text>().text = $"You Lost! Orbs Collected: {totalOrbs}/70";
            } 
        }
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
