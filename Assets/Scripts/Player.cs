using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 2.0f;
    public GameObject cyl;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        
        Physics.Raycast(cyl.transform.position, Vector3.forward * 2, out RaycastHit hit, Mathf.Infinity);
        Debug.DrawRay(cyl.transform.position, Vector3.forward * hit.distance, Color.green, 50);
        Debug.Log(hit.collider);
    }

}
