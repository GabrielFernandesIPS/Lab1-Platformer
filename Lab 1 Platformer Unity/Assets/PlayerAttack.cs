using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject PlayerBullet;
    [SerializeField] private Transform bulletPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject g =  Instantiate(PlayerBullet, bulletPos.position , Quaternion.identity);
            if(transform.localScale.x < 0)
            {
                g.GetComponent<PlayerBullet>().InvertBullet();
            }  
        }

    }
}
