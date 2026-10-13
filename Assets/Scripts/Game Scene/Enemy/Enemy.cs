using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering.VirtualTexturing;
using VContainer;
using VContainer.Unity;
using static UnityEditor.Progress;

public class Enemy : MonoBehaviour, IEvents
{
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _distanceRate = 0.5f;

    [SerializeField] private EnemyState _enemyState;
    [SerializeField] private Player _playerTarget;

    [SerializeField] private List<Item> _item = new List<Item>();

    private IObjectResolver _objectResolver;

    [Inject]
    public void Construct(IObjectResolver objectResolver)
    {
        _objectResolver = objectResolver;
    }

    private void Awake()
    {
        //ServiceLocator.Register(this);
        //ServiceLocator.Register<IEvents>(this);
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
        _playerTarget.Damage();
        //ServiceLocator.Get<Player>().Damage();
    }

    public void Damage()
    {
        _enemyState = EnemyState.Die;
    }

    public void EnemyDie()
    {
        Item randomItem = _item[Random.Range(0, _item.Count)];

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
