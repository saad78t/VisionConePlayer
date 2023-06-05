using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void Start()
    {
        gameOverMenu.SetActive(false);
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
        gameOverMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
