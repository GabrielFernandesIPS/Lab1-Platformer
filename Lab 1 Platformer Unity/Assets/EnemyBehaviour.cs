using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3 _enemySpeed;
    [SerializeField] private float _enemyLife;
    [SerializeField] private GameObject _enemyBullet;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void EnemyChase()
    {
        transform.Translate(_enemySpeed * Time.deltaTime);
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
