using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEntryPoint : MonoBehaviour
{
    [SerializeField] private MenuUIManager _menuUIManager;

    private MenuModel _model;
    private MenuPresenter _presenter;

    private void Awake()
    {
        // 1. Создаем Модель
        _model = new MenuModel();

        // 2. Создаем Презентер, передавая в него Модель и View
        _presenter = new MenuPresenter(_model, _menuUIManager);
    }
}
