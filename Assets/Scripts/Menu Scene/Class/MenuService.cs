using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuService
{
    //Метод Старт игры
    public void StartGame()
    {
        Debug.Log("Загружаем игровую сцену");
        SceneManager.LoadScene("Game");
    }

    // Метод Выход из игры
    public void QuitGame()
    {
        Debug.Log("Выходим из игры");
        Application.Quit();
    }
}
