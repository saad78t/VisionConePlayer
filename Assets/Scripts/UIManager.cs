using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public Texture2D BoxBorder;

     FadeInOut GameOverFade;

    private void Start()
    {
        GameOverFade = GetComponent<FadeInOut>();
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


}
