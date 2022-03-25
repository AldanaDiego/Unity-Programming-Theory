using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject enemyBullet;

    public static BulletPool Instance;

    private int playerPoolSize = 10;
    private int enemyPoolSize = 20;
    private int playerIndex;
    private int enemyIndex;
    private List<GameObject> playerBulletPool;
    private List<GameObject> enemyBulletPool;

    void Awake()
    {
        if (BulletPool.Instance != null) {
            Destroy(this.gameObject);
            return;
        }

        BulletPool.Instance = this;
        DontDestroyOnLoad(this.gameObject);

        this.playerBulletPool = new List<GameObject>();
        this.enemyBulletPool = new List<GameObject>();
        this.playerIndex = -1;
        this.enemyIndex = -1;

        GameObject aux;
        for (int i = 0; i < this.playerPoolSize; i++) {
            aux = Instantiate(this.playerBullet);
            aux.SetActive(false);
            this.playerBulletPool.Add(aux);
        }
        for (int i = 0; i < this.enemyPoolSize; i++) {
            aux = Instantiate(this.enemyBullet);
            aux.SetActive(false);
            this.enemyBulletPool.Add(aux);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPlayerBullet()
    {
        this.playerIndex++;
        if (this.playerIndex >= this.playerPoolSize) {
            this.playerIndex = 0;
        }
        return this.playerBulletPool[this.playerIndex];
    }

    public GameObject GetEnemyBullet()
    {
        this.enemyIndex++;
        if (this.enemyIndex >= this.enemyPoolSize) {
            this.enemyIndex = 0;
        }
        return this.enemyBulletPool[this.enemyIndex];
    }
}
