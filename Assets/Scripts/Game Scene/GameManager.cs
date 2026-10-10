using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class GameManager : MonoBehaviour
{
    private UIManager _uiManager;

    //Âûחûגאול סונגטס UIManager קונוח injection 
    [Inject]
    public void Counstruct(UIManager uiManager)
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
