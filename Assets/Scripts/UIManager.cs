using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IUIInterface
{
    private void Awake()
    {
        ServiceLocator.Register(this);
    }

    //Вызываем метод из IUIInterface
    public void AddEXP()
    {
        Debug.Log("You GET EXP");
    }
}
