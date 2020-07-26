using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Camera cam;
    public LayerMask layerMask;
    public Collider[] colliders;
    public Shader originalShader, greenShader;
    public Text[] orbText;
    public int[] orbsObtained = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
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
            if (other.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Red"))
            {
                orbsObtained[0]++;
                orbText[0].text = orbsObtained[0].ToString();
                Destroy(other.gameObject);
            }
            else if (other.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Orange"))
            {
                orbsObtained[1]++;
                orbText[1].text = orbsObtained[1].ToString();
                Destroy(other.gameObject);
            }
            else if (other.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Yellow"))
            {
                orbsObtained[2]++;
                orbText[2].text = orbsObtained[2].ToString();
                Destroy(other.gameObject);
            }
            else if (other.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Green"))
            {
                orbsObtained[3]++;
                orbText[3].text = orbsObtained[3].ToString();
                Destroy(other.gameObject);
            }
            else if (other.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Blue"))
            {
                orbsObtained[4]++;
                orbText[4].text = orbsObtained[4].ToString();
                Destroy(other.gameObject);
            }
            else if (other.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Indigo"))
            {
                orbsObtained[5]++;
                orbText[5].text = orbsObtained[5].ToString();
                Destroy(other.gameObject);
            }
            else if (other.gameObject.GetComponent<MeshRenderer>().material.name.Contains("Violet"))
            {
                orbsObtained[6]++;
                orbText[6].text = orbsObtained[6].ToString();
                Destroy(other.gameObject);
            }
        }
    }
}
