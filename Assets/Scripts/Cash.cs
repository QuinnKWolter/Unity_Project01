using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : MovingObject
{
	public Sprite[] cashSprites;

	public void chooseSprite()
	{
		int i = Random.Range(0, cashSprites.Length);
		GetComponent<SpriteRenderer>().sprite = cashSprites[i];
	}
}
