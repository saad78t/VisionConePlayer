using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerPause : MonoBehaviour
{
    public GameObject pauseGame;
    bool isPaused;
    public CanvasGroup pauseWindow;
    public float TimeToFade = 1f;
    public bool fadeIn1 = false;
    public bool fadeOut2 = false;

    bool disableEscapeButton;

    private void Start()
    {
        //gameOverMenu.SetActive(false);
        isPaused = false;
        disableEscapeButton = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { StartCoroutine(PauseGame()); }

        if (fadeIn1 == true)
        {
            if (pauseWindow.alpha < 1)
            {
                pauseWindow.alpha += TimeToFade * Time.deltaTime;
                if (pauseWindow.alpha >= 1)
                {
                    fadeIn1 = false;
                }
            }
        }

        if (fadeOut2 == true)
        {
            if (pauseWindow.alpha >= 0)
            {
                pauseWindow.alpha -= TimeToFade * Time.deltaTime;
                if (pauseWindow.alpha == 0)
                {
                    fadeOut2 = false;
                }
            }
        }
    }


    IEnumerator PauseGame()
    {
            isPaused = !isPaused;
            if (isPaused && !disableEscapeButton)
            {
                FadeIn1();
                yield return new WaitForSeconds(1);
                Time.timeScale = 0;
                disableEscapeButton = true;
            }
            if (!isPaused && disableEscapeButton)
            {
                Time.timeScale = 1;
                FadeOut2();
                yield return new WaitForSeconds(1);
                disableEscapeButton = false;
            }
    }

    public void Resume()
    {
        Debug.Log("Resum Clicked");
        Time.timeScale = 1;
        FadeOut2();
    }

    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void FadeIn1()
    {
        fadeIn1 = true;
    }

    public void FadeOut2()
    {
        fadeOut2 = true;
    }

}
