using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private GameManager _gameManager;


    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;

    protected override void Configure(IContainerBuilder builder)
    {
        //Регистрируем существующий на сцене компонент UIManager без использования интерфейса
        builder.RegisterComponent(_uiManager);

        //Регистрируем существующий на сцене компонент GameManager без использования интерфейса
        builder.RegisterComponent(_gameManager);

        //Регистрируем существующий на сцене компонент Player без использования интерфейса
        builder.RegisterComponent(_player);

        //Регистрируем существующий на сцене компонент Enemy без использования интерфейса
        builder.RegisterComponent(_enemy);
    }
}
