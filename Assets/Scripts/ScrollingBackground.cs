using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
	// Top and bottom pieces of the road
	public GameObject top;
	public GameObject bottom;

	//
	private float endPosition;
	private float spriteHeight;
	public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
		spriteHeight = bottom.GetComponentInChildren<SpriteRenderer>().bounds.size.y;
		bottom.transform.position = new Vector2(bottom.transform.position.x, bottom.transform.position.y + spriteHeight);
		endPosition = top.transform.position.y + spriteHeight;
    }

    // Update is called once per frame
    void Update()
    {
		// Move both pieces at a cosntant rate
		movePiece(bottom);
		movePiece(top);

		// If either of the two pieces passes the initial position of the bottom piece reset it
		if (bottom.transform.position.y >= endPosition) {
			resetPiece(bottom);
		}
		if (top.transform.position.y >= endPosition) {
			resetPiece(top);
		}
    }

	// Reset piece above camera view
	void resetPiece(GameObject piece) {
		piece.transform.position = new Vector2(piece.transform.position.x, piece.transform.position.y - spriteHeight * 2);
	}

	// Move the piece at a constant speed
	void movePiece(GameObject piece) {
		piece.transform.Translate(new Vector2(transform.up.y * (movementSpeed/100), 0f));
	}
}
