using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GetItem : MonoBehaviour
{
    //[SerializeField] private UIManager _uimanager;
    private IUIInterface _uiManager;

    //Âûחûגאול סונגטס UIManager קונוח injection 
    [Inject]
    public void Construct(IUIInterface uIManager)
    {
        _uiManager = uIManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _uiManager.AddEXP();

            Destroy(gameObject);
        }
    }
}
