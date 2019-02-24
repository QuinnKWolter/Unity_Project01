using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudNear : MonoBehaviour
{
	public Sprite[] cloudNearSprites;

	public void chooseSprite()
	{
		int i = Random.Range(0, cloudNearSprites.Length);
		GetComponent<SpriteRenderer>().sprite = cloudNearSprites[i];
	}
}
