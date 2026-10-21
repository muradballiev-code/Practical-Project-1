using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System;
using UnityEngine;
using UnityEngine.UI;

using VContainer;
using VContainer.Unity;

public class MenuUIManager : MonoBehaviour, IMenuView
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _quitGameButton;

    public event Action StartClicked;
    public event Action QuitClicked;


    private void Start()
    {
        _startGameButton.onClick.AddListener(OnClickStartGameButton);
        _quitGameButton.onClick.AddListener(OnClickQuitGameButton);
    }

    public void OnClickStartGameButton()
    {
        if (StartClicked == null)
        {
            Debug.Log("StartClicked Action event wasn't found");
            return;
        }
        StartClicked.Invoke(); //вызываем метод внутри MenuPresenter
    }

    public void OnClickQuitGameButton()
    {
        if (QuitClicked == null)
        {
            Debug.Log("QuitClicked Action event wasn't found");
            return;
        }
        QuitClicked.Invoke(); //вызываем метод внутри MenuPresenter
    }

    private void OnDisable()
    {
        _startGameButton.onClick.RemoveListener(OnClickStartGameButton);
        _quitGameButton.onClick.RemoveListener(OnClickQuitGameButton);
    }
}
