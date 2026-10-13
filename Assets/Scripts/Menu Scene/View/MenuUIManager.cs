using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

public class MenuUIManager : MonoBehaviour
{
    protected MenuPresenter _presenter;

    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _quitGameButton;

    private MenuService _menuService;

    //Âûחûגאול סונגטס MenuService קונוח injection 
    [Inject]
    public void Construct(MenuService menuService)
    {
        _menuService = menuService;
    }

    public void Init(MenuPresenter presenter)
    {
        _presenter = presenter;
    }

    private void Start()
    {
        _startGameButton.onClick.AddListener(OnClickStartGameButton);
        _quitGameButton.onClick.AddListener(OnClickQuitGameButton);
    }

    public void OnClickStartGameButton()
    {
        _presenter?.ClickStartGame();

        //_menuService.StartGame();
    }

    public void OnClickQuitGameButton()
    {
        //_menuService.QuitGame();

        _presenter?.ClickQuitGame();
    }
}
