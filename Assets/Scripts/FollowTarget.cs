using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    
    public GameObject targetToFollow;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(targetToFollow.transform.position.x, transform.position.y, targetToFollow.transform.position.z);
    }
}
