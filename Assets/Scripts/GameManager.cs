using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;
	private Pooler obstaclePooler;
	private Pooler tokenPooler;
	private Pooler cashPooler;
	private Pooler cloudFarPooler;
	private Pooler cloudNearPooler;
	private Pooler sparklePooler;
	private HurtPlanes hurtPlanes;
	private static int score;

	public GameObject spawnerGO, hurtPlanesGO, playerGO;
	public Text scoreText, gameOverText;
	public Slider healthSlider;
	public float hurtPlaneSpeed;

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

	public float getHurtPlaneSpeed()
	{
		return hurtPlaneSpeed;
	}

	public void setHurtPlaneSpeed(float s)
	{
		if (s <= .005f)
		{
			s = .005f;
		}
		hurtPlaneSpeed = s;
	}

	public void pushHurtPlanes(float x)
	{
		hurtPlanes.pushBack(x);
	}

	void GetReferences()
	{
		obstaclePooler = GameObject.Find("ObstaclePool").GetComponent<Pooler>();
		tokenPooler = GameObject.Find("TokenPool").GetComponent<Pooler>();
		cashPooler = GameObject.Find("CashPool").GetComponent<Pooler>();
		cloudFarPooler = GameObject.Find("CloudFarPool").GetComponent<Pooler>();
		cloudNearPooler = GameObject.Find("CloudNearPool").GetComponent<Pooler>();
		sparklePooler = GameObject.Find("SparklePool").GetComponent<Pooler>();
		hurtPlanes = GameObject.Find("HurtPlanes").GetComponent<HurtPlanes>();
	}

	public void sparkle(Vector2 v)
	{
		GameObject sparkle = sparklePooler.getPooledObject();
		sparkle.transform.position = v;
		sparkle.SetActive(true);
	}

	public Pooler getObstaclePool()
	{
		return obstaclePooler;
	}

	public Pooler getTokenPool()
	{
		return tokenPooler;
	}

	public Pooler getCashPool()
	{
		return cashPooler;
	}

	public Pooler getCloudFarPool()
	{
		return cloudFarPooler;
	}

	public Pooler getCloudNearPool()
	{
		return cloudNearPooler;
	}

	public Pooler getSparklePool()
	{
		return sparklePooler;
	}

	public void changeHealth(float x)
	{
		healthSlider.value += x;
		Debug.Log(healthSlider.value);
		if (healthSlider.value <= 0)
		{
			gameOver(false);
		}
	}

	public void changeScore(int x)
	{
		score += x;
		Debug.Log("Score is: " + getScore());
		scoreText.text = "Score: " + getScore();
		if (score >= 3000)
		{
			gameOver(true);
		}
	}

	public int getScore()
	{
		return score;
	}

	public void gameOver(bool win)
	{
		hurtPlanesGO.gameObject.SetActive(false);
		spawnerGO.gameObject.SetActive(false);
		playerGO.gameObject.SetActive(false);
		sparkle(playerGO.transform.position);
		playerGO.GetComponent<PlayerController>().sparkleSound();
		if (win)
		{
			gameOverText.text = "Congratulations!";
		}
		else
		{
			gameOverText.text = "Better Luck Next Time!";
		}
	}
}
