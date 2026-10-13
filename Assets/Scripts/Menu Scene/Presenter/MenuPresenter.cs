using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuPresenter
{
    private readonly MenuModel _model;
    private readonly MenuUIManager _view;

    public MenuPresenter(MenuModel model, MenuUIManager view)
    {
        _model = model;
        _view = view;

        // Инициализируем View
        _view.Init(this);
    }

    public void ClickStartGame()    
    {
        _model.StartGame();
    }

    public void ClickQuitGame()
    {
        _model.QuitGame();
    }
}
