using VContainer;
using VContainer.Unity;

using UnityEngine;

public class MenuLifetimeScope : LifetimeScope
{
    [SerializeField] private MenuUIManager _menuUiManager;
    [SerializeField] private MenuGameManager _menuGameManager;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<MenuService>(Lifetime.Singleton); //–егистриурем MenuService C# класс не использу€ интерфейс


        builder.RegisterComponent(_menuGameManager); //–егистриурем _menuGameManager компонент со сцены не использу€ интерфейс

        builder.RegisterComponent(_menuUiManager); //–егистриурем MenuUIManager компонент со сцены не использу€ интерфейс
    }
}
