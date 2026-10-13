using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerSO _player;
    [SerializeField] private Transform _hand;

    private PlayerMovement _playerMovement;
    private PlayerRotation _playerRotation;

    private UIManager _uiManager;

    //Сервис регистрирует себя используя ServiceLocator
    private void Awake()
    {
        //ServiceLocator.Register(this);
        //ServiceLocator.Register<IEvents>(this);
    }

    //Вызываем сервис UIManager через injection 
    [Inject]
    public void Construct(UIManager uIManager)
    {
        _uiManager = uIManager;
    }

    private void Start()
    {
        _playerMovement = new PlayerMovement();
        _playerRotation = new PlayerRotation();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRotation();

        if (Input.GetMouseButton(0))
        {
            Attack();
        }
    }

    public void PlayerMove()
    {
        _playerMovement.PlayerMoveController(transform, _player.moveSpeed);
    }

    public void PlayerRotation()
    {
        _playerRotation.PlayerRotationController(transform);
    }

    public void Attack()
    {
        Vector3 direct = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                //Вызываем метод Damage из IEvents
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
        _uiManager.GameOver();
    }
}
