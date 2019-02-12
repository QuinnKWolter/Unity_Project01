using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// The Rigidbody of this object
	Rigidbody2D rb;
	public float speed;
	public float forceScalar;
	float xSpeed = 0;
	float ySpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Demonstrating four means of movement.
		// (1) Translate by Axis
//		float xSpeed = Input.GetAxis("Horizontal");
//		float ySpeed = Input.GetAxis("Vertical");
//		transform.Translate(new Vector2(xSpeed, ySpeed) * speed);

		// (2) Physics
//		float xSpeed = Input.GetAxis("Horizontal");
//		float ySpeed = Input.GetAxis("Vertical");
//		rb.AddForce(new Vector2(xSpeed, ySpeed) * speed);

		// (3) AddForce by GetKey
//		if(Input.GetKey(KeyCode.D)) {
//			xSpeed = 1;
//		} else if(Input.GetKey(KeyCode.A)) {
//			xSpeed = -1;
//		}
//		if(Input.GetKey(KeyCode.W)) {
//			ySpeed = 1;
//		} else if(Input.GetKey(KeyCode.S)) {
//			ySpeed = -1;
//		}
//		rb.AddForce(new Vector2(xSpeed, ySpeed) * speed);

		// (4) Set Velocity
//		if(Input.GetKey(KeyCode.D)) {
//			xSpeed = 1;
//		} else if(Input.GetKey(KeyCode.A)) {
//			xSpeed = -1;
//		} else {
//			xSpeed = 0;
//		}
//		if(Input.GetKey(KeyCode.W)) {
//			ySpeed = 1;
//		} else if(Input.GetKey(KeyCode.S)) {
//			ySpeed = -1;
//		} else {
//			ySpeed = 0;
//		}
//		rb.velocity = new Vector2(xSpeed, ySpeed) * speed;

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
}
