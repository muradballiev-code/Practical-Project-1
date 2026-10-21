using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

public class BootstrapLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {

    }

    private void Start()
    {
        SceneManager.LoadScene("Menu");
    }
}
