using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "player.asset", menuName = "Player/PlayerInfo")]
public class PlayerSO : ScriptableObject
{
    public float moveSpeed = 5f;
}
