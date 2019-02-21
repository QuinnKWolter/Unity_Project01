using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// The Rigidbody of this object
	Rigidbody2D rb;
	public float forceScalar;
	public GameManager gameManager;

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
		if (transform.position.x > 10f)
		{
			transform.position = new Vector2(10f, transform.position.y);
			rb.velocity = new Vector2(0, 0);
		}
		else if (transform.position.x < -10f)
		{
			transform.position = new Vector2(-10f, transform.position.y);
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
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		gameManager.increaseScore();
		Debug.Log(col);
		col.gameObject.SetActive(false);
	}
}
