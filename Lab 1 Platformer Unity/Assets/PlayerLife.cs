using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    Rigidbody2D rb;
	public float healthAmount;

	// Use this for initialization
	void Start () {
		healthAmount = 8;
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (healthAmount <= 0)
			Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Bullet"))
		{
			healthAmount -= 2f;
		}

		if (healthAmount <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
