using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementPattern : MonoBehaviour
{
    protected float rightBound = 10.0f;
    protected bool isMoving = true;

    protected float bulletSpeed = 15.0f;
    
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
        if (this.gameObject.tag == "Bullet") {
            this.GetComponent<Bullet>().DeleteMovement();
            this.gameObject.SetActive(false);
        }
    }
}