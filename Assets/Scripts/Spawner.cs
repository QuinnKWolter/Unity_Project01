using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public float lastSpawn = 0;
	public float lastCloudSpawn = 0;
	private Pooler obstaclePool;
	private Pooler tokenPool;
	private Pooler cashPool;
	private Pooler cloudNearPool;
	private Pooler cloudFarPool;

	void Awake()
	{
		obstaclePool = GameManager.instance.getObstaclePool();
		tokenPool = GameManager.instance.getTokenPool();
		cashPool = GameManager.instance.getCashPool();
		cloudNearPool = GameManager.instance.getCloudNearPool();
		cloudFarPool = GameManager.instance.getCloudFarPool();
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
		GameObject cash = cashPool.getPooledObject();
		GameObject cloudFar = cloudFarPool.getPooledObject();
		GameObject cloudNear = cloudNearPool.getPooledObject();
		if ((Time.fixedTime - lastSpawn) > 1.25f)
		{
			if (obstacle != null && Random.Range(0, 100) < 40)
			{
				obstacle.transform.position = new Vector2(transform.position.x, transform.position.y);
				obstacle.SetActive(true);
				obstacle.GetComponent<Obstacle>().chooseSprite();
				lastSpawn = Time.fixedTime;
			}
			else if (token != null && Random.Range(0, 100) > 70)
			{
				cash.transform.position = new Vector2(transform.position.x, transform.position.y);
				cash.SetActive(true);
				cash.GetComponent<Cash>().chooseSprite();
				lastSpawn = Time.fixedTime;
			}
			else
			{
				token.transform.position = new Vector2(transform.position.x, transform.position.y);
				token.SetActive(true);
				token.GetComponent<Token>().chooseSprite();
				lastSpawn = Time.fixedTime;
			}
		}
		if ((Time.fixedTime - lastCloudSpawn) > 1.5f)
		{
			if (cloudNear != null && Random.Range(0, 100) < 50)
			{
				cloudNear.transform.position = new Vector2(transform.position.x, transform.position.y);
				cloudNear.SetActive(true);
				cloudNear.GetComponent<CloudNear>().chooseSprite();
				lastCloudSpawn = Time.fixedTime;
			}
			else
			{
				cloudFar.transform.position = new Vector2(transform.position.x, transform.position.y);
				cloudFar.SetActive(true);
				cloudFar.GetComponent<CloudFar>().chooseSprite();
				lastCloudSpawn = Time.fixedTime;
			}
		}
	}
}
