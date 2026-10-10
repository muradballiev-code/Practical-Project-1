using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _quitGameButton;

    private MenuService _menuService;

    //Âûחûגאול סונגטס MenuService קונוח injection 
    [Inject]
    public void Construct(MenuService menuService)
    {
        _menuService = menuService;
    }

    private void Start()
    {
        _startGameButton.onClick.AddListener(OnClickStartGameButton);
        _quitGameButton.onClick.AddListener(OnClickQuitGameButton);
    }

    public void OnClickStartGameButton()
    {
        Debug.Log("Button Pressed");

        _menuService.StartGame();
    }

    public void OnClickQuitGameButton()
    {
        _menuService.QuitGame();
    }
}
