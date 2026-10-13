using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    public void PlayerMoveController(Transform playerTransform, float playerSpeed)
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(h, 0, v).normalized;

        playerTransform.Translate(move * playerSpeed * Time.deltaTime);
    }
}
