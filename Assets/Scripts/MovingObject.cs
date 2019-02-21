using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
	public int speed;
	public int rotationSpeed;
	protected Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate()
	{
		rb.velocity = new Vector2(0f, speed);
		rb.AddTorque(rotationSpeed);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		rb.angularVelocity = 0;
		gameObject.SetActive(false);
	}
}
