using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;
	private Pooler obstaclePooler;
	private Pooler tokenPooler;
	private Pooler explosionPooler;
	private static int score;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		GetReferences();
	}


    // Start is called before the first frame update
    private void Start()
    {
		score = 0;
    }

	void GetReferences()
	{
		obstaclePooler = GameObject.Find("ObstaclePool").GetComponent<Pooler>();
		tokenPooler = GameObject.Find("TokenPool").GetComponent<Pooler>();
		explosionPooler = GameObject.Find("ExplosionPool").GetComponent<Pooler>();
	}

	public Pooler getObstaclePool()
	{
		return obstaclePooler;
	}

	public Pooler getTokenPool()
	{
		return tokenPooler;
	}

	public Pooler getExplosionPool()
	{
		return explosionPooler;
	}

	public void increaseScore()
	{
		score++;
		Debug.Log("Score is: " + getScore());
	}

	public int getScore()
	{
		return score;
	}
}
