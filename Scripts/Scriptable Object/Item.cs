using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "item.asset", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public GameObject prefab;
}
