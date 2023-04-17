using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject PlayerBullet;
    [SerializeField] private Transform bulletPos;
    [SerializeField] private float chargeMaxWaitTime;
    private float chargeTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        chargeTimer = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        chargeTimer += Time.deltaTime;    
        if (Input.GetKeyDown(KeyCode.S) && chargeTimer > chargeMaxWaitTime)
        {
            GameObject g =  Instantiate(PlayerBullet, bulletPos.position , Quaternion.identity);
            if(transform.localScale.x < 0)
            {
                g.GetComponent<PlayerBullet>().InvertBullet();
            }
            chargeTimer = 0;
        }

    }
}
