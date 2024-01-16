using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;

    private void Awake()
    {
        Debug.Log("GameManager Awake called");
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("GameManager Instance set");
        }
        else if (Instance != this)
        {
            Debug.Log("GameManager Instance already exists, destroying duplicate");
            Destroy(gameObject);
        }
    }


    #endregion

    public float currentScore = 0f;

    public bool isPlaying = false;

    public UnityEvent onPlay = new UnityEvent();

    public void StartGame()
    {
        Debug.Log("Button Clicked");
        onPlay.Invoke();
        isPlaying = true;
        SceneManager.LoadScene("SampleScene");
    }
    public string FormatScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }
    public void GameOver()
    {
        currentScore = 0f;
        isPlaying = false;
        SceneManager.LoadScene("GameOver");
    }

    void Update()
    {
        //Debug.Log($"Update called, isPlaying: {isPlaying}");
        if (isPlaying)
        {
            currentScore += Time.deltaTime;
            //Debug.Log(currentScore);
        }
    }

}
