using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
	private Rigidbody2D rigidbody;
	public GameManager gameManager;
	public float forceScalar;

	void Awake()
	{
		if (GameManager.instance == null)
			Instantiate(gameManager);
	}

    // Start is called before the first frame update
    void Start()
    {
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (Input.GetKey(KeyCode.A))
		{
			rigidbody.AddForce(Vector2.left * forceScalar);
		}
		if (Input.GetKey(KeyCode.D))
		{
			rigidbody.AddForce(-Vector2.left * forceScalar);
		}

		if (transform.position.x > 10f)
		{
			transform.position = new Vector2(10f, transform.position.y);
		}
		else if (transform.position.x < -10f)
		{
			transform.position = new Vector2(-10f, transform.position.y);
		}
    }

	private void OnTriggerEnter2D(Collision col)
	{
		gameManager.increaseScore();
		col.gameObject.SetActive(false);
	}
}
