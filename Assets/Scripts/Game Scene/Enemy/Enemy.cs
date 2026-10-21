using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class Enemy : MonoBehaviour, IEvents
{
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _distanceRate = 1.5f;

    [SerializeField] private EnemyState _enemyState;

    [SerializeField] private List<Item> _item = new List<Item>();

    private IObjectResolver _objectResolver;
    private Player _playerTarget;

    [Inject]
    public void Construct(IObjectResolver objectResolver, Player playerTarget)
    {
        _objectResolver = objectResolver;
        _playerTarget = playerTarget;
    }

    private void Start()
    {
        _enemyState = EnemyState.Follow;
    }

    private void Update()
    {
        switch (_enemyState)
        {
            case EnemyState.Follow:
                EnemyFollow();
            break;

            case EnemyState.Attack:
                Attack();
            break;

            case EnemyState.Die:
                EnemyDie();
            break;

            default:

            break;
        }
    }

    public void EnemyFollow()
    {
        transform.position = Vector3.MoveTowards(transform.position, _playerTarget.transform.position, _moveSpeed * Time.deltaTime);

        Vector3 direction = (_playerTarget.transform.position - transform.position).normalized;

        transform.rotation = Quaternion.LookRotation(direction);

        if (Vector3.Distance(_playerTarget.transform.position, transform.position) < _distanceRate)
        {
            _enemyState = EnemyState.Attack;
        }
        else 
        {
            _enemyState = EnemyState.Follow;
        }
    }

    public void Attack()
    {
        if (Vector3.Distance(_playerTarget.transform.position, transform.position) < _distanceRate)
        {
            _playerTarget.Damage();
        }
        else
        {
            _enemyState = EnemyState.Follow;
        }
    }

    public void Damage()
    {
        _enemyState = EnemyState.Die;
    }

    public void EnemyDie()
    {
        Item randomItem = _item[Random.Range(0, _item.Count)];

        if (randomItem != null)
        { 
            //Простой способ Спавна через Unity Mono
            //Instantiate(randomItem.prefab, transform.position, transform.rotation);

        
            //Cпособ Спавна через VContainer с последующим Inject
            //Способ-1
            //GetItem item = Instantiate(randomItem.prefab, transform.position, transform.rotation);
            //_objectResolver.Inject(item);
            //Способ-2
            _objectResolver.Instantiate(randomItem.prefab, transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
    }
}
