using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class MoveStraightRight : MovementPattern
{
    //POLYMORPHISM
    protected override void Move()
    {
        this.transform.Translate(Vector3.right * Time.deltaTime * this.bulletSpeed, Space.World);
    }

    //POLYMORPHISM
    protected override void CheckMoveStatus()
    {
        if (this.transform.position.x > this.rightBound)
        {
            this.isMoving = false;
        }
    }
}
