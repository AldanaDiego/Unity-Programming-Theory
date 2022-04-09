using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 7.0f;
    private float posX = -9.0f;
    private float verticalBound = 5.0f;
    private Vector3 limitYPositive;
    private Vector3 limitYNegative;

    // Start is called before the first frame update
    void Start()
    {
        this.limitYPositive = new Vector3(this.posX, this.verticalBound, 0);
        this.limitYNegative = new Vector3(this.posX, this.verticalBound * -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Vertical");
        this.transform.position += new Vector3(0, movement * this.speed * Time.deltaTime, 0);
        
        if (this.transform.position.y > this.limitYPositive.y) {
            this.transform.position = this.limitYPositive;
        } else if (this.transform.position.y < this.limitYNegative.y) {
            this.transform.position = this.limitYNegative;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject bullet = BulletPool.Instance.GetPlayerBullet();
            bullet.GetComponent<Bullet>().Shoot(this.transform.position, typeof(MoveStraightRight));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet") {
            other.GetComponent<Bullet>().Deactivate();
            this.gameObject.SetActive(false);
            GameManager.Instance.TriggerGameOver();
        }
    }

    public void Respawn()
    {
        this.gameObject.SetActive(true);
    }
}
