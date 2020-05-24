using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{

    public void restart()
    {
        Debug.Log("game is reloading");
        SceneManager.LoadScene("Level1");

        Time.timeScale = 1;
    }
}
