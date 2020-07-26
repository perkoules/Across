using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereDrop : MonoBehaviour
{
    private CubeSpawner cubeSpawner;

    private void Start()
    {
        cubeSpawner = FindObjectOfType<CubeSpawner>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            SceneManager.LoadScene(8);
        }
        else if (other.gameObject.CompareTag("FloorCubeTag"))
        {
            cubeSpawner.floorTiles.Remove(other.gameObject.transform.parent.gameObject);
            Destroy(other.gameObject.transform.parent.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("OrbTag"))
        {
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
