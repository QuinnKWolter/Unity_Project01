using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public float lastSpawn = 0;
	public GameManager gameManager;
	private Pooler obstaclePool;
	private Pooler tokenPool;

	void Awake()
	{
		if (GameManager.instance == null)
			Instantiate(gameManager);

		obstaclePool = GameManager.instance.getObstaclePool();
		tokenPool = GameManager.instance.getTokenPool();
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		objectSpawn();
    }

	void objectSpawn()
	{
		GameObject car = obstaclePool.getPooledObject();
		GameObject coin = tokenPool.getPooledObject();
		if ((Time.fixedTime - lastSpawn) > 1.5f)
		{
			if (car != null && Random.Range(0, 100) < 20)
			{
				car.transform.position = new Vector2(transform.position.x, transform.position.y);
				car.SetActive(true);
				lastSpawn = Time.fixedTime;
			}
			else if (coin != null && Random.Range(0, 100) < 20)
			{
				coin.transform.position = new Vector2(transform.position.x, transform.position.y);
				coin.SetActive(true);
				lastSpawn = Time.fixedTime;
			}
		}
	}
}
