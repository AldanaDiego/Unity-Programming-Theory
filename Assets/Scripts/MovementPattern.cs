using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementPattern : MonoBehaviour
{
    protected float rightBound = 12.0f;
    protected float leftBound = -12.0f;
    protected float upperBound = 5.0f;
    protected float lowerBound = -5.0f;
    protected bool isMoving = true;

    protected float bulletSpeed = 15.0f;
    protected float movingSpeedSlow = 2.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        //this.isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isMoving) {
            this.Move();
            this.CheckMoveStatus();
        } else {
            this.OnStoppedMoving();
        }
    }

    protected abstract void Move();

    protected abstract void CheckMoveStatus();

    protected void OnStoppedMoving()
    {
        if (this.gameObject.tag == "Bullet" || this.gameObject.tag == "PlayerBullet") {
            this.GetComponent<Bullet>().DeleteMovement();
            this.gameObject.SetActive(false);
        }
    }

    public void SetIsMoving(bool moving)
    {
        this.isMoving = moving;
    }
}