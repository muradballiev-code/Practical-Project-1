using UnityEngine;
using VContainer;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerSO _player;
    [SerializeField] private Transform _hand;

    private PlayerMovement _playerMovement;
    private PlayerRotation _playerRotation;

    private IUIInterface _uiManager;

    //Вызываем сервис UIManager через injection 
    [Inject]
    public void Construct(IUIInterface uIManager)
    {
        _uiManager = uIManager;
    }

    private void Start()
    {
        _playerMovement = new PlayerMovement(); //Создаём новый экземпляр класса PlayerMovement
        _playerRotation = new PlayerRotation(); //Создаём новый экземпляр класса PlayerRotation
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRotation();

        if (Input.GetMouseButtonDown(0))
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
                if (hit.transform.TryGetComponent<IEvents>(out IEvents enemy))
                {
                    enemy.Damage();
                }
            }
        }
    }

    public void Damage()
    {
        _uiManager.GameOver();
    }
}
