using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraightRight : MovementPattern
{
    protected override void Move()
    {
        this.transform.Translate(Vector3.right * Time.deltaTime * this.bulletSpeed);
    }

    protected override void CheckMoveStatus()
    {
        if (this.transform.position.x > this.rightBound)
        {
            this.isMoving = false;
        }
    }
}
