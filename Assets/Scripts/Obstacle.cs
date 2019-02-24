using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MovingObject
{
	public Sprite[] obstacleSprites;

	public void chooseSprite()
	{
		int i = Random.Range(0, obstacleSprites.Length);
		GetComponent<SpriteRenderer>().sprite = obstacleSprites[i];
	}
}
