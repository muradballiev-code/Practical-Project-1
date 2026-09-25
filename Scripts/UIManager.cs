using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.Register(this);
    }

    public void AddEXP()
    {
        Debug.Log("You GET EXP");
    }
}
