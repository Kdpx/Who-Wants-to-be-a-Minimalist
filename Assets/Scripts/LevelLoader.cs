using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public bool isDone = false;
    public bool isGameOver = false;
    public Animator transition;
    public float transitionTime = 0.5f;

    public GameObject pauseScreen;
    private bool gamePaused = false;

    // Update is called once per frame
    void Update()
    {
        CheckProgress();
    }

    private void CheckProgress()
    {
        if (isDone)
        {
            NextScene();
        }

        if (isGameOver)
        {
            StartCoroutine(LoadGameOver());
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadGameOver()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("GameOver");
    }

    public void Pause()
    {
        gamePaused = true;
        pauseScreen.SetActive(true);
    }

    public void Resume()
    {
        gamePaused = false;
        pauseScreen.SetActive(false);
    }

    //0 is index of MainMenu scene
    public void Quit()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void NextScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    //Change it back to 1 to play Intro first
    public void PlayGame()
    {
        StartCoroutine(LoadLevel(1));
    }
}
