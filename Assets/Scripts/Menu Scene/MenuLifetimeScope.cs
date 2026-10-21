using VContainer;
using VContainer.Unity;

using UnityEngine;

public class MenuLifetimeScope : LifetimeScope
{
    [SerializeField] private MenuUIManager _menuUiManager;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<MenuPresenter>(Lifetime.Singleton); //–егистриурем MenuPresenter C# класс не использу€ интерфейс
        builder.Register<MenuModel>(Lifetime.Singleton); //–егистриурем MenuModel C# класс не использу€ интерфейс


        builder.RegisterComponent(_menuUiManager).As<IMenuView>(); //–егистриурем MenuUIManager компонент со сцены не использу€ интерфейс
    }
}
