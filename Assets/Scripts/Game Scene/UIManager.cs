using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IUIInterface
{
    //Вызываем метод из IUIInterface
    public void AddEXP()
    {
        Debug.Log("You GET EXP");
    }

    public void GameOver()
    {
        Debug.Log("You dead");
    }

    public void PauseGame()
    {
        Debug.Log("Game paused");
    }
}
