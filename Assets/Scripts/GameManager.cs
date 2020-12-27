using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject completeLevelUI;
    public float slowness = 10f;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            StartCoroutine(RestartLevel());
        }
    }


    void SlowTimeSpeed()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime /= slowness;
    }

    void RestoreTimeSpeed()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime *= slowness;
    }

    IEnumerator RestartLevel()
    {
        SlowTimeSpeed();

        yield return new WaitForSeconds(1f / slowness);

        RestoreTimeSpeed();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
