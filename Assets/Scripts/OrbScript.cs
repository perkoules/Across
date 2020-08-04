using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbScript : MonoBehaviour
{
    private string materialName;
    public int collectedOrbs = 0;
    private char[] toTrim = { ' ' };
    private Text orbText;
    private void Start()
    {
        materialName = GetComponent<MeshRenderer>().material.name.Substring(5);
        materialName = materialName.Replace(" (Instance)", "");
        orbText = GameObject.FindGameObjectWithTag($"{materialName}TextTag").GetComponent<Text>();
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collectedOrbs = PlayerPrefs.GetInt($"{materialName}") + 1;
            PlayerPrefs.SetInt($"{materialName}", collectedOrbs);
            print(collectedOrbs);
            orbText.text = PlayerPrefs.GetInt($"{materialName}").ToString();
            Destroy(this.gameObject);
        }
    }
}
