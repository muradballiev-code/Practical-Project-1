using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GetItem : MonoBehaviour
{
    //[SerializeField] private UIManager _uimanager;
    private UIManager _uimanager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _uimanager.AddEXP();

            /*
            if (ServiceLocator.TryGet<UIManager>(out var uimanager))
            {
                uimanager.AddEXP();
            }
            */
            //ServiceLocator.Get<UIManager>().AddEXP();
        }
    }
}
