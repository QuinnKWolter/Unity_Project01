using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
	public int speed;
	protected Rigidbody2D rigidB;

    // Start is called before the first frame update
    void Start()
    {
		rigidB = GetComponent<Rigidbody2D>();
    }

	public void movement(int speed)
	{
		rigidB.velocity = new Vector2(0f, -speed);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		rigidB.angularVelocity = 0;
		gameObject.SetActive(false);
	}
}
