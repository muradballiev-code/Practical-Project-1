using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _mouseSensitivity = 200f;

    [SerializeField] private Transform _hand;

    // Сервис регистрирует себя
    private void Awake()
    {
        //ServiceLocator.Register(this);
        //ServiceLocator.Register<IEvents>(this);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveController();
        PlayerRotationController();

        if (Input.GetMouseButton(0))
        {
            Attack();
        }
    }

    public void PlayerMoveController()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(h, 0, v).normalized;

        transform.Translate(move * _moveSpeed * Time.deltaTime);
    }

    public void PlayerRotationController()
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
            Vector3 direction = hit.point - transform.position;

            //direction.y = 0f;
            //transform.rotation = Quaternion.LookRotation(direction);

            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }

    public void Attack()
    {
        Vector3 direct = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<IEvents>().Damage();

                /*
                IEvents enemyEvents = ServiceLocator.Get<IEvents>();
                if (enemyEvents != null) 
                {
                    enemyEvents.Damage();
                }
                */
            }
        }
    }

    public void Damage()
    {
        Destroy(this.gameObject);
    }
}
