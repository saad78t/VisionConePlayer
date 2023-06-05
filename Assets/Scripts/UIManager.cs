using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu, pauseGame;
    bool isPaused;
    public Texture2D BoxBorder;

    public FadeInOut GameOverFade;
    public CanvasGroup pauseWindow;
    public float TimeToFade = 1f;
    public bool fadeIn = false;
    public bool fadeOut = false;

    bool disableEscapeButton;

    private void Start()
    {
        //gameOverMenu.SetActive(false);
        isPaused = false;
        disableEscapeButton = false;
    }

    private void Update()
    {
        StartCoroutine(PauseGame());
        if (fadeIn == true)
        {
            if (pauseWindow.alpha < 1)
            {
                pauseWindow.alpha += TimeToFade * Time.deltaTime;
                if (pauseWindow.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut == true)
        {
            if (pauseWindow.alpha >= 0)
            {
                pauseWindow.alpha -= TimeToFade * Time.deltaTime;
                if (pauseWindow.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }

    }

    private void OnEnable()
    {
        PlayerHealth.onPlayerDeath += EnablegameOverMenu;
    }

    private void OnDisable()
    {
        PlayerHealth.onPlayerDeath -= EnablegameOverMenu;
    }

    public void EnablegameOverMenu()
    {
        //gameOverMenu.SetActive(true);
        GameOverFade.FadeIn();
    }

    public void RestartGame()
    {
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        GameOverFade.FadeOut();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    IEnumerator PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            isPaused = !isPaused;
            if (isPaused && !disableEscapeButton)
            {
                FadeIn();
                yield return new WaitForSeconds(1);
                Time.timeScale = 0;
                disableEscapeButton = true;
            }
            if (!isPaused && disableEscapeButton)
            {
                Time.timeScale = 1;
                FadeOut();
                yield return new WaitForSeconds(1);
                disableEscapeButton = false;
            }
        }
    }


    //void OnGUI()
    //{
    //    GUIStyle headStyle = new GUIStyle();

    //    if (isPaused)
    //    {
    //        GUI.Label(new Rect(11, 100, 330, 315), BoxBorder, headStyle);
    //    }
    //    else
    //    {
    //        GUI.Label(new Rect(11, 100, 330, 315), "", headStyle);
    //    }
    //}

    public void FadeIn()
    {
        fadeIn = true;
    }

    public void FadeOut()
    {
        fadeOut = true;
    }

}
