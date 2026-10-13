using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation
{
    public void PlayerRotationController(Transform playerTransform)
    {
        //Получаем координаты мыши на экране через луч
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        /*
        //Создаём плоскость пересечения луча с позицией игрока
        Plane ground = new Plane(Vector3.up, transform.position);

        //Проверяем пересечение луча с плоскостью
        if (ground.Raycast(ray, out float distance))
        {
            //Получаем 3D-точку, куда указывает мышь
            Vector3 mouseWorldPos = ray.GetPoint(distance);

            //Получаем направление от игрока к мыши
            Vector3 direction = mouseWorldPos - transform.position;

            direction.y = 0f;

            //Проверяем, что направление не нулевое
            if (direction.sqrMagnitude > 0.001f)
            {
                //Поворачиваем игрока в сторону мыши
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
        */

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 direction = hit.point - playerTransform.position;

            //direction.y = 0f;
            //transform.rotation = Quaternion.LookRotation(direction);

            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            playerTransform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}
