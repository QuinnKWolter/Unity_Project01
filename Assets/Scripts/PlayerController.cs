using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// The Rigidbody of this object
	Rigidbody2D rb;
	public float forceScalar = 5;
	public GameManager gameManager;
	public AudioClip collectSound;

	private bool inHurtPlane = false;

	void Awake()
	{
		if (GameManager.instance == null)
			Instantiate(gameManager);
	}

    // Start is called before the first frame update
    void Start()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if (transform.position.x > 10.5f)
		{
			transform.position = new Vector2(10.5f, transform.position.y);
			rb.velocity = new Vector2(0, 0);
		}
		else if (transform.position.x < -10.5f)
		{
			transform.position = new Vector2(-10.5f, transform.position.y);
			rb.velocity = new Vector2(0, 0);
		}
    }

	// Update is called once per frame
	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.A))
		{
			rb.AddForce(Vector2.left * forceScalar);
		}
		if (Input.GetKey(KeyCode.D))
		{
			rb.AddForce(-Vector2.left * forceScalar);
		}

		if (inHurtPlane)
		{
			gameManager.changeHealth(-.1f);
		}
	}

	public void sparkleSound()
	{
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Token")
		{
			if (col.GetComponent<SpriteRenderer>().sprite.name == "heldhands")
			{
				gameManager.changeScore(250);
				gameManager.setHurtPlaneSpeed(gameManager.getHurtPlaneSpeed()-.005f);
				gameManager.pushHurtPlanes(1.5f);
				gameManager.changeHealth(10);
			}
			else if (col.GetComponent<SpriteRenderer>().sprite.name == "books")
			{
				gameManager.changeScore(100);
				gameManager.setHurtPlaneSpeed(gameManager.getHurtPlaneSpeed()-.003f);
				gameManager.pushHurtPlanes(.5f);
				gameManager.changeHealth(5);
			}
			else
			{
				gameManager.changeScore(50);
				gameManager.setHurtPlaneSpeed(gameManager.getHurtPlaneSpeed()-.002f);
				gameManager.pushHurtPlanes(.5f);
				gameManager.changeHealth(5);
			}
		}
		else if (col.tag == "Cash")
		{
			if (col.GetComponent<SpriteRenderer>().sprite.name == "diamond")
			{
				gameManager.changeScore(100);
				gameManager.setHurtPlaneSpeed(gameManager.getHurtPlaneSpeed()+.003f);
				gameManager.pushHurtPlanes(1.5f);
			}
			else if (col.GetComponent<SpriteRenderer>().sprite.name == "moneybag")
			{
				gameManager.changeScore(50);
				gameManager.setHurtPlaneSpeed(gameManager.getHurtPlaneSpeed()+.002f);
				gameManager.pushHurtPlanes(1);
			}
			else
			{
				gameManager.changeScore(25);
				gameManager.setHurtPlaneSpeed(gameManager.getHurtPlaneSpeed()+.001f);
				gameManager.pushHurtPlanes(.5f);
			}
		}
		else if (col.tag == "Obstacle")
		{
			if (col.GetComponent<SpriteRenderer>().sprite.name == "gun")
			{
				gameManager.setHurtPlaneSpeed(gameManager.getHurtPlaneSpeed()+.005f);
				gameManager.pushHurtPlanes(-2);
				gameManager.changeHealth(-20);
			}
			else if (col.GetComponent<SpriteRenderer>().sprite.name == "hypodermicneedle")
			{
				gameManager.setHurtPlaneSpeed(gameManager.getHurtPlaneSpeed()+.003f);
				gameManager.pushHurtPlanes(-1.5f);
				gameManager.changeHealth(-15);
			}
			else
			{
				gameManager.setHurtPlaneSpeed(gameManager.getHurtPlaneSpeed()+.001f);
				gameManager.pushHurtPlanes(-1);
				gameManager.changeHealth(-10);
			}
		}
		else if (col.tag == "HurtPlane")
		{
			inHurtPlane = true;
		}
		else 
		{
			Debug.Log("Wat?");
		}

		if (col.tag != "HurtPlane")
		{
			sparkleSound();
			gameManager.sparkle(col.transform.position);
			col.gameObject.SetActive(false);
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "HurtPlane")
		{
			inHurtPlane = false;
		}
	}
}
