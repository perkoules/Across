using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private Animator animator;
    public float speed;
    public Camera cam;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 1000) && Input.GetKey(KeyCode.Mouse0) && hit.transform.gameObject.CompareTag("FloorCubeTag"))
        {
            transform.position = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);
        }
    }
}
