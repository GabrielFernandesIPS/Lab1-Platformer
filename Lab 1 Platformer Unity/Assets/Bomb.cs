using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 0;
    float temporizador = 2;
    GameObject bomba;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= 2)
        {

            Collider2D[] others = Physics2D.OverlapCircleAll(transform.position, 3);

            foreach (Collider2D other in others)
            {
                if (other.CompareTag("Enemy"))
                {
                    Destroy(other.gameObject);
                }
            }

        }




    }

}
