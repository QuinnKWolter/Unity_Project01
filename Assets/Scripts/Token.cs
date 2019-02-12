using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MovingObject
{
    // Update is called once per frame
    void FixedUpdate()
    {
		movement(speed);
    }
}
