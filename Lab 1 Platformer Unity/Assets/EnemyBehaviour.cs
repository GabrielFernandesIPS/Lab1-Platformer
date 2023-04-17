using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _enemyLife;
    [SerializeField] private GameObject _enemyBullet;
    private Rigidbody2D _enemyRb;
    Collider2D[] _enemyLineSight;
    Collider2D[] _enemyAttackRange;


    void Start()
    {
        _enemyRb = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        _enemyLineSight = Physics2D.OverlapCircleAll(transform.position, 1.5f);
        _enemyAttackRange = Physics2D.OverlapCircleAll(transform.position, 1f);

        foreach (Collider2D collider in _enemyLineSight)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                if(transform.position.x > collider.gameObject.transform.position.x)
                {
                    _enemyRb.velocity = new Vector3(_enemySpeed, _enemyRb.velocity.y);
                    Vector3 scale = transform.localScale;
                    scale.x = 1;
                    transform.localScale = scale;
                }
                else
                {
                    _enemyRb.velocity = new Vector3(-_enemySpeed, _enemyRb.velocity.y);
                    Vector3 scale = transform.localScale;
                    scale.x = -1;
                    transform.localScale = scale;
                }
            }
            
        }
        foreach (Collider2D collider2 in _enemyAttackRange)
        {

        }
    }

    private void EnemyChase()
    {
        _enemyRb.velocity = new Vector3(_enemySpeed, _enemyRb.velocity.y);
    }
    private void EnemyAttack()
    {
        //Debug.Log("attack");
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
