using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFar : MonoBehaviour
{
	public Sprite[] cloudFarSprites;

	public void chooseSprite()
	{
		int i = Random.Range(0, cloudFarSprites.Length);
		GetComponent<SpriteRenderer>().sprite = cloudFarSprites[i];
	}
}
