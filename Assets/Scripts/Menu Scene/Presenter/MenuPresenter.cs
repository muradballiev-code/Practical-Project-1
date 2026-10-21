using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPresenter
{
    private readonly MenuModel _model;
    private readonly IMenuView _view;

    public MenuPresenter(MenuModel model, IMenuView view)
    {
        _model = model;
        _view = view;

        //Инициализируем события на кнопки для View
        _view.StartClicked += ClickStartGame;
        _view.QuitClicked += ClickQuitGame;
    }

    public void ClickStartGame()    
    {
        _model.StartGame();
    }

    public void ClickQuitGame()
    {
        _model.QuitGame();
    }

    public void OnDisable()
    {
        _view.StartClicked -= ClickStartGame;
        _view.QuitClicked -= ClickQuitGame;
    }
}
