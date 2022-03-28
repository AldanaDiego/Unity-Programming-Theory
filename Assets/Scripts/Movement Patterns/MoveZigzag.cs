using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZigzag : MovementPattern
{
    private Vector3 dirVertical = Vector3.up;
    private Vector3 dirHorizontal = Vector3.right;
    private float horizontalOffset = 1.0f;
    private float startPositionX;

    private void Start()
    {
        this.startPositionX = this.GetComponent<Enemy>().GetEnterStagePosition();   
    }
    
    protected override void Move()
    {
        this.transform.Translate(this.dirVertical * Time.deltaTime * this.movingSpeedFast, Space.World);
        this.transform.Translate(this.dirHorizontal * Time.deltaTime * this.movingSpeedSlow, Space.World);
    }

    protected override void CheckMoveStatus()
    {
        if (this.transform.position.y > this.upperBound) {
            this.dirVertical = Vector3.down;
        } else if (this.transform.position.y < this.lowerBound) {
            this.dirVertical = Vector3.up;
        }

        if (this.transform.position.x > (this.startPositionX + this.horizontalOffset)) {
            this.dirHorizontal = Vector3.left;
        } else if (this.transform.position.x < (this.startPositionX - this.horizontalOffset)) {
            this.dirHorizontal = Vector3.right;
        }
    }
}
