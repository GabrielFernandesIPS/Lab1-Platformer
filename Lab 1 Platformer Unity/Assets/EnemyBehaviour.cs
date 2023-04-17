using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _enemyLife;
    [SerializeField] private GameObject _enemyBullet;
    private Rigidbody2D _enemyRb;


    void Start()
    {
        _enemyRb = GetComponent<Rigidbody2D>();        
    }

    
    void Update()
    {
        EnemyChase();
    }

    private void EnemyChase()
    {
        _enemyRb.velocity = new Vector3(_enemySpeed, _enemyRb.velocity.y);
    }
    private void EnemyAttack()
    {
        //
    }
    public void EnemyTakeDamage(float damage)
    {
        _enemyLife -= damage;
        if(_enemyLife <= 0)
        {
            EnemyDeath();
        }
    }
    private void EnemyDeath()
    {
        //
    }
    public float ReturnEnemyLife()
    {
        return _enemyLife;
    }



}
