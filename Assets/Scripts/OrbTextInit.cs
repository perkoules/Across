using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbTextInit : MonoBehaviour
{
    private Text orbText;
    void Start()
    {
        orbText = GetComponent<Text>();
        orbText.text = PlayerPrefs.GetInt($"{gameObject.name.Replace("Text", "")}").ToString();
    }

}
