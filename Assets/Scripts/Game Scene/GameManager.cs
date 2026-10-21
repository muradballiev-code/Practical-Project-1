using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class GameManager : MonoBehaviour
{
    private IUIInterface _uiManager;

    //Âûחûגאול סונגטס UIManager קונוח injection 
    [Inject]
    public void Construct(IUIInterface uiManager)
    {
        _uiManager = uiManager;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _uiManager.PauseGame();
        }
    }
}
