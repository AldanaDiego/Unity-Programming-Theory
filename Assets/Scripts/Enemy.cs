using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int shootDelay = 1;
    [SerializeField] private float enterStagePosition;
    [SerializeField] private float enterStageSpeed;
    
    private EnemySpawner parentSpawner;
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
            this.transform.Translate(Vector3.left * Time.deltaTime * this.enterStageSpeed, Space.World);
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

    public void SetParentSpawn(EnemySpawner enemySpawner)
    {
        this.parentSpawner = enemySpawner;
    }

    public float GetEnterStagePosition()
    {
        return this.enterStagePosition;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet") {
            other.GetComponent<Bullet>().Deactivate();
            this.hp--;
            if (this.hp <= 0) {
                this.parentSpawner.EnemyDestroyed();
                Destroy(this.gameObject);
            }
        }
    }
}
