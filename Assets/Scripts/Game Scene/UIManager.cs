using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IUIInterface
{
    //Сервис регистрирует себя используя ServiceLocator
    private void Awake()
    {
        //ServiceLocator.Register(this);
    }

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

    /*
    private void OnDestroy()
    {
        // Очищаем реестр при уничтожении сцены, чтобы избежать утечек памяти
        //ServiceLocator.Unregister<UIManager>();
    }
    */
}
