using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int shootDelay = 1;
    [SerializeField] private float enterStagePosition;
    
    private float enterStageSpeed = 3.5f;
    private bool isEnteringStage = true;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MovementPattern>().SetIsMoving(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isEnteringStage) {
            this.transform.Translate(Vector3.left * Time.deltaTime * this.enterStageSpeed);
            if (this.transform.position.x <= this.enterStagePosition) {
                this.isEnteringStage = false;
                this.GetComponent<MovementPattern>().SetIsMoving(true);
                StartCoroutine(Shoot());
            }
        }
        
    }

    private IEnumerator Shoot()
    {
        while (true) {
            yield return new WaitForSeconds(this.shootDelay);
            GameObject bullet = BulletPool.Instance.GetEnemyBullet();
            bullet.GetComponent<Bullet>().Shoot(this.transform.position, typeof(MoveStraightLeft));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet") {
            Destroy(other.gameObject);
            this.hp--;
            if (this.hp <= 0) {
                Destroy(this.gameObject);
            }
        }
    }
}
