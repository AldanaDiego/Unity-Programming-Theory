using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;

    private float spawnPositionX = 12.0f;
    private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        this.SpawnWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnWave()
    {
        this.enemyCount = Random.Range(2, 4);
        for (int i = 0; i < this.enemyCount; i++) {
            int prefab = Random.Range(0, this.enemyPrefabs.Count);
            Vector3 spawnPosition = new Vector3(
                spawnPositionX,
                -3.0f + ((12 - (this.enemyCount * 3.0f)) * i),
                0
            );
            GameObject enemy = Instantiate(
                this.enemyPrefabs[prefab],
                spawnPosition,
                this.enemyPrefabs[prefab].transform.rotation
            );
            enemy.GetComponent<Enemy>().SetParentSpawn(this);
        }
    }

    public void EnemyDestroyed()
    {
        this.enemyCount--;
        if (this.enemyCount <= 0) {
            this.SpawnWave();
        }
    }
}
