using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraightLeft : MovementPattern
{
    protected override void Move()
    {
        this.transform.Translate(Vector3.left * Time.deltaTime * this.bulletSpeed, Space.World);
    }

    protected override void CheckMoveStatus()
    {
        if (this.transform.position.x < this.leftBound)
        {
            this.isMoving = false;
        }
    }
}
