using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class MoveStraightLeft : MovementPattern
{
    //POLYMORPHISM
    protected override void Move()
    {
        this.transform.Translate(Vector3.left * Time.deltaTime * this.bulletSpeed, Space.World);
    }

    //POLYMORPHISM
    protected override void CheckMoveStatus()
    {
        if (this.transform.position.x < this.leftBound)
        {
            this.isMoving = false;
        }
    }
}
