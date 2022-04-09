using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class MoveUpDownSlow : MovementPattern
{
    private Vector3 direction = Vector3.up;

    //POLYMORPHISM
    protected override void Move()
    {
        this.transform.Translate(direction * Time.deltaTime * this.movingSpeedSlow, Space.World);
    }

    //POLYMORPHISM
    protected override void CheckMoveStatus()
    {
        if (this.transform.position.y > this.upperBound) {
            this.direction = Vector3.down;
        } else if (this.transform.position.y < this.lowerBound) {
            this.direction = Vector3.up;
        }
    }
}
