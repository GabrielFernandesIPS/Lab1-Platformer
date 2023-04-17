using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _enemyLife;
    [SerializeField] private GameObject _enemyBullet;
    private Rigidbody2D _enemyRb;
    private Collider2D[] _enemyLineSight;
    private Collider2D[] _enemyAttackRange;
    [SerializeField] private float _sightRange;
    [SerializeField] private float _attackRange;


    void Start()
    {
        _enemyRb = GetComponent<Rigidbody2D>();
      
        
    }

    
    void Update()
    {
        //Definicao da range do campo de visao e alcance do ataque
        _enemyLineSight = Physics2D.OverlapCircleAll(transform.position, _sightRange);
        _enemyAttackRange = Physics2D.OverlapCircleAll(transform.position, _attackRange);

        //Deteta o Jogador e Segue-o se estiver no seu campo de vis�o
        foreach (Collider2D collider in _enemyLineSight)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                if(transform.position.x > collider.gameObject.transform.position.x)
                {
                    
                    _enemyRb.velocity = new Vector3(_enemySpeed, _enemyRb.velocity.y);//Inverte a velocidade se o jogador estiver � esquerda do inimigo
                    Vector3 scale = transform.localScale;
                    scale.x = 1;
                    transform.localScale = scale;
                }
                else
                {
                    
                    _enemyRb.velocity = new Vector3(-_enemySpeed, _enemyRb.velocity.y);//Inverte a velocidade se o jogador estiver � direita do inimigo
                    Vector3 scale = transform.localScale;
                    scale.x = -1;
                    transform.localScale = scale;
                }
            }
            
        }
        //Deteta o Jogodar e Dispara se estiver ao seu alcance
        foreach (Collider2D collider in _enemyAttackRange)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                EnemyAttack();
            }
        }
    }

    private void EnemyChase()
    {
        _enemyRb.velocity = new Vector3(_enemySpeed, _enemyRb.velocity.y);
    }
    private void EnemyAttack()
    {
        GameObject g = Instantiate(_enemyBullet, transform.position, Quaternion.identity);
        if (transform.localScale.x < 0)
        {
            g.GetComponent<PlayerBullet>().InvertBullet();
        }
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
