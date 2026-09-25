using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset = new Vector3(12.29261f, 12.43256f, -8.959816f);

    private void LateUpdate()
    {
        if (_player == null) return;

        transform.position = _player.position + _offset;
    }
}
