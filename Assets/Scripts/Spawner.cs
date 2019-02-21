using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public float lastSpawn = 0;
	private Pooler obstaclePool;
	private Pooler tokenPool;
	private Pooler cashPool;

	void Awake()
	{
		obstaclePool = GameManager.instance.getObstaclePool();
		tokenPool = GameManager.instance.getTokenPool();
		cashPool = GameManager.instance.getCashPool();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		objectRandomSpawn();
    }

	void objectRandomSpawn()
	{
		transform.position = new Vector2(Random.Range(-8, 8), transform.position.y);

		GameObject obstacle = obstaclePool.getPooledObject();
		GameObject token = tokenPool.getPooledObject();
		if ((Time.fixedTime - lastSpawn) > 1.5f)
		{
			if (obstacle != null && Random.Range(0, 100) < 50)
			{
				obstacle.transform.position = new Vector2(transform.position.x, transform.position.y);
				obstacle.SetActive(true);
				obstacle.GetComponent<Obstacle>().chooseSprite();
				lastSpawn = Time.fixedTime;
			}
			else if (token != null && Random.Range(0, 100) > 50)
			{
				token.transform.position = new Vector2(transform.position.x, transform.position.y);
				token.SetActive(true);
				token.GetComponent<Token>().chooseSprite();
				lastSpawn = Time.fixedTime;
			}
		}
	}
}
