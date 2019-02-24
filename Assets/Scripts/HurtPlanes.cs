using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlanes : MonoBehaviour
{
	public GameObject L, R;
	public GameManager gm;

	private float speed;

	void FixedUpdate()
    {
		speed = gm.getHurtPlaneSpeed();
		if (L.transform.position.x < -40)
		{
			L.transform.position = new Vector2(L.transform.position.x+speed, 0);
			R.transform.position = new Vector2(R.transform.position.x-speed, 0);
		}
		else
		{
			L.transform.position = new Vector2(-40, 0);
			R.transform.position = new Vector2(40, 0);
		}
    }

	public void pushBack(float x)
	{
		if (L.transform.position.x < -40 || x > 0)
		{
			L.transform.position = new Vector2(L.transform.position.x-x, 0);
			R.transform.position = new Vector2(R.transform.position.x+x, 0);
		}
		else if (L.transform.position.x > -47)
		{
			L.transform.position = new Vector2(L.transform.position.x-x, 0);
			R.transform.position = new Vector2(R.transform.position.x+x, 0);
		}
	}

	void OnTriggerStay(Collider col)
	{
		Debug.Log(col.tag);
		if (col.tag == "HurtPlane")
		{
			Debug.Log("HurtPlane");
		}
	}
}
