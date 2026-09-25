using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Enemy : MonoBehaviour, IEvents
{
    private enum EnemyState
    { 
        Follow,
        Attack,
        Die,
    }

    [SerializeField] private float _moveSpeed = 5;

    [SerializeField] private EnemyState _enemyState;
    [SerializeField] private Player _playerTarget;

    [SerializeField] private List<Item> _item = new List<Item>();


    private void Start()
    {
        _enemyState = EnemyState.Follow;


        Debug.Log(_item[0].prefab);
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

        if (Vector3.Distance(_playerTarget.transform.position, transform.position) < 0.5f)
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
    }

    public void Damage()
    {
        _enemyState = EnemyState.Die;
    }

    public void EnemyDie()
    {
        Item randomItem = _item[Random.Range(0, _item.Count)];
        Instantiate(randomItem.prefab, transform.position, transform.rotation);

        Destroy(this.gameObject);
    }
}
