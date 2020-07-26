using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Camera cam;
    public LayerMask layerMask;
    public Collider[] colliders;
    public GameObject orb;
    public Shader originalShader, greenShader;
    public Text[] orbText;
    public int[] orbsObtained = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
    private int totalOrbs = 0;
    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.SetInt("Red", 0);
            PlayerPrefs.SetInt("Orange", 0);
            PlayerPrefs.SetInt("Yellow", 0);
            PlayerPrefs.SetInt("Green", 0);
            PlayerPrefs.SetInt("Blue", 0);
            PlayerPrefs.SetInt("Indigo", 0);
            PlayerPrefs.SetInt("Violet", 0); 
        }
        orbsObtained[0] = PlayerPrefs.GetInt("Red");
        orbsObtained[1] = PlayerPrefs.GetInt("Orange");
        orbsObtained[2] = PlayerPrefs.GetInt("Yellow");
        orbsObtained[3] = PlayerPrefs.GetInt("Green");
        orbsObtained[4] = PlayerPrefs.GetInt("Blue");
        orbsObtained[5] = PlayerPrefs.GetInt("Indigo");
        orbsObtained[6] = PlayerPrefs.GetInt("Violet");
        orbText[0].text = PlayerPrefs.GetInt("Red").ToString();
        orbText[1].text = PlayerPrefs.GetInt("Orange").ToString();
        orbText[2].text = PlayerPrefs.GetInt("Yellow").ToString();
        orbText[3].text = PlayerPrefs.GetInt("Green").ToString();
        orbText[4].text = PlayerPrefs.GetInt("Blue").ToString();
        orbText[5].text = PlayerPrefs.GetInt("Indigo").ToString();
        orbText[6].text = PlayerPrefs.GetInt("Violet").ToString();
    }
    private void Start()
    {
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
        if (Physics.Raycast(ray, out RaycastHit hit, 1000) && hit.transform.gameObject.CompareTag("FloorCubeTag"))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider.gameObject.GetComponent<FloorCube>().canBeStepped)
            {
                transform.position = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("OrbTag"))
        {
            if (other.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Red"))
            {
                orbsObtained[0]++;
                PlayerPrefs.SetInt("Red", orbsObtained[0]);
                orbText[0].text = orbsObtained[0].ToString();
                Destroy(other.gameObject);
            }
            else if (other.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Orange"))
            {
                orbsObtained[1]++;
                PlayerPrefs.SetInt("Orange", orbsObtained[1]);
                orbText[1].text = orbsObtained[1].ToString();
                Destroy(other.gameObject);
            }
            else if (other.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Yellow"))
            {
                orbsObtained[2]++;
                PlayerPrefs.SetInt("Yellow", orbsObtained[2]);
                orbText[2].text = orbsObtained[2].ToString();
                Destroy(other.gameObject);
            }
            else if (other.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Green"))
            {
                orbsObtained[3]++;
                PlayerPrefs.SetInt("Green", orbsObtained[3]);
                orbText[3].text = orbsObtained[3].ToString();
                Destroy(other.gameObject);
            }
            else if (other.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Blue"))
            {
                orbsObtained[4]++;
                PlayerPrefs.SetInt("Blue", orbsObtained[4]);
                orbText[4].text = orbsObtained[4].ToString();
                Destroy(other.gameObject);
            }
            else if (other.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Indigo"))
            {
                orbsObtained[5]++;
                PlayerPrefs.SetInt("Indigo", orbsObtained[5]);
                orbText[5].text = orbsObtained[5].ToString();
                Destroy(other.gameObject);
            }
            else if (other.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Violet"))
            {
                orbsObtained[6]++;
                PlayerPrefs.SetInt("Violet", orbsObtained[6]);
                orbText[6].text = orbsObtained[6].ToString();
                Destroy(other.gameObject);
            }
        }
    }
}
