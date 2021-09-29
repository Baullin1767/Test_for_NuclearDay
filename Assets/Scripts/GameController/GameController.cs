using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Fader fader;

    void Start()
    {
        StartGame();
    }

    public void StartGame() 
    {
        StartCoroutine(StartRoutine());
    }
    public void LoseGame() 
    {
        StartCoroutine(LoseRoutine());
    }

    IEnumerator StartRoutine() 
    {
        yield return StartCoroutine(fader.Fade(false));
        fader.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    IEnumerator LoseRoutine() 
    {
        Time.timeScale = 0.4f;
        fader.gameObject.SetActive(true);
        yield return StartCoroutine(fader.Fade(true));
        StartCoroutine(fader.StartBlinkRetryBtn());
    }
}
