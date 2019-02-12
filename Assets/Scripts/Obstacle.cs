using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MovingObject
{
	public Pooler explosionPool;
	public float rotationSpeed;

	private Pooler explosionPooler;
	public GameManager gameManager;

	void Awake()
	{
		if (GameManager.instance == null)
			Instantiate(gameManager);

		explosionPooler = GameManager.instance.getExplosionPool();
	}

    void FixedUpdate()
    {
		movement(speed);
		rotate();
    }

	void rotate()
	{
		rigidB.AddTorque(rotationSpeed);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		GameObject explosionInstance = explosionPooler.getPooledObject();
		if (explosionInstance != null)
		{
			explosionInstance.transform.position = new Vector2(transform.position.x, transform.position.y);
			explosionInstance.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}
