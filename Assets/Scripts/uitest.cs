using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uitest : MonoBehaviour
{
    public CanvasGroup pauseWindow;
    bool isPaused, test;
    public float TimeToFade = 1f;

    private void Start()
    {
        isPaused = true;
        test = true;
    }

    private void Update()
    {
        StartCoroutine(PauseGame());
    }

    IEnumerator PauseGame()
    {
        while (test)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("third line");

                if (isPaused)
                    Resume(); //Close Pause Menu
                else
                    Pause(); //Open Pause Menu
            }
            yield return null;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }


    IEnumerator Fade(float startValue, float goalValue)
    {
        pauseWindow.alpha = startValue;
        if (goalValue > startValue)
        {
            while (pauseWindow.alpha != goalValue && pauseWindow.alpha < goalValue)
            {
                pauseWindow.alpha += TimeToFade * Time.unscaledDeltaTime;
                yield return null;
            }
        }
        else
        {
            while (pauseWindow.alpha != goalValue && pauseWindow.alpha > goalValue)
            {
                pauseWindow.alpha -= TimeToFade * Time.unscaledDeltaTime;
                yield return null;
            }
        }
        pauseWindow.alpha = goalValue;
        yield return new WaitForEndOfFrame();

    }

    public void FadeIn() => StartCoroutine(Fade(1, 0));
    public void FadeOut() => StartCoroutine(Fade(0, 1));
}
