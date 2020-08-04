using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioClip[] audioclips;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        InitializeCollectedOrbs();
        FinalSceneText();
        ChooseMusic();
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
    private static void FinalSceneText()
    {
        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            if (TotalOrbs() == 70)
            {
                GameObject.FindGameObjectWithTag("EndTextTag").GetComponent<Text>().text = $"You Won! Orbs Collected: {TotalOrbs()}/70";
            }
            else
            {
                GameObject.FindGameObjectWithTag("EndTextTag").GetComponent<Text>().text = $"You Lost! Orbs Collected: {TotalOrbs()}/70";
            }
        }
    }

    public void ChooseMusic()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 8)
        {
            audioSource.clip = audioclips[0];
            audioSource.volume = 0.15f;
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
            audioSource.clip = audioclips[1];
            audioSource.volume = 1f;
            audioSource.Play();
        }
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
    
    private static int TotalOrbs()
    {
        return PlayerPrefs.GetInt("Red") + PlayerPrefs.GetInt("Yellow") + 
            PlayerPrefs.GetInt("Orange") + PlayerPrefs.GetInt("Green") + PlayerPrefs.GetInt("Blue")+
            PlayerPrefs.GetInt("Indigo") + PlayerPrefs.GetInt("Violet");
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
