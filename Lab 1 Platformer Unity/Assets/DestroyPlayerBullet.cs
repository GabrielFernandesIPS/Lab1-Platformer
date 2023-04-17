using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
