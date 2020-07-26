﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public static void SetRedText(int orbsObtained)
    {
        PlayerPrefs.SetInt("Red", orbsObtained);
    }
    public static int GetRedText()
    {
        return PlayerPrefs.GetInt("Red");
    }
    public static void SetOrangeText(int orbsObtained)
    {
        PlayerPrefs.SetInt("Orange", orbsObtained);
    }
    public static int GetOrangeText()
    {
        return PlayerPrefs.GetInt("Orange");
    }
    public static void SetYellowText(int orbsObtained)
    {
        PlayerPrefs.SetInt("Yellow", orbsObtained);
    }
    public static int GetYellowText()
    {
        return PlayerPrefs.GetInt("Yellow");
    }
    public static void SetGreenText(int orbsObtained)
    {
        PlayerPrefs.SetInt("Green", orbsObtained);
    }
    public static int GetGreenText()
    {
        return PlayerPrefs.GetInt("Green");
    }
    public static void SetBlueText(int orbsObtained)
    {
        PlayerPrefs.SetInt("Blue", orbsObtained);
    }
    public static int GetBlueText()
    {
        return PlayerPrefs.GetInt("Blue");
    }

    public static void SetIndigoText(int orbsObtained)
    {
        PlayerPrefs.SetInt("Indigo", orbsObtained);
    }
    public static int GetIndigoText()
    {
        return PlayerPrefs.GetInt("Indigo");
    }
    public static void SetVioletText(int orbsObtained)
    {
        PlayerPrefs.SetInt("Violet", orbsObtained);
    }
    public static int GetVioletText()
    {
        return PlayerPrefs.GetInt("Violet");
    }
       
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
