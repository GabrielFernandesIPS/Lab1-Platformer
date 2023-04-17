using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionDamage;
    [SerializeField] private float _fuseTime;
    private float _waitToExplode;
    private Animator _bombAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _bombAnimator = GetComponent<Animator>();
        _waitToExplode = 0;
    }

    // Update is called once per frame
    void Update()
    {
        string animation = "IdleBomb";
        _waitToExplode += Time.deltaTime;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);
        if(_waitToExplode > _fuseTime)
        {
            
            
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.CompareTag("Enemy"))
                {
                    collider.gameObject.GetComponent<EnemyBehaviour>().EnemyTakeDamage(_explosionDamage);
                }
               
            }
            Destroy(gameObject);

        }
        _bombAnimator.Play(animation);
    }
    
        
   
}
