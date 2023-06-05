using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    bool isPaused;
    public Texture2D BoxBorder;

    public FadeInOut GameOverFade;


    private void Start()
    {
        //gameOverMenu.SetActive(false);
        isPaused = false;
    }

    private void Update()
    {
        PauseGame();
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

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            isPaused = !isPaused;
            Time.timeScale = 0;
            if (!isPaused)
            {
                Time.timeScale = 1;
            }
        }
    }


    void OnGUI()
    {
        GUIStyle headStyle = new GUIStyle();

        if (isPaused)
        {
            GUI.Label(new Rect(11, 100, 330, 315), BoxBorder, headStyle);
        }
        else
        {
            GUI.Label(new Rect(11, 100, 330, 315), "", headStyle);
        }
    }

}
