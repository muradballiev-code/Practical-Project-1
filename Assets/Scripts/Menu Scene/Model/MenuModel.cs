using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuModel : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
