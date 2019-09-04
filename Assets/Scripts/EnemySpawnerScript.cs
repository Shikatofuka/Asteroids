using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {

    public float minX = -2.2f, maxX = 2.2f;

    public GameObject[] asteroid_Prefabs;
    public GameObject[] enemyPrefabs;
    public GameObject extraLifePrefab;

    public float timer = 2f;

    void Start() {
        Invoke("SpawnEnemies", timer);
    }

    void SpawnEnemies() {
        float posX = Random.Range(minX, maxX);
        Vector3 temp = transform.position;
        temp.x = posX;

        if(Random.Range(0, 4) == 1) {
            Instantiate(extraLifePrefab, temp, Quaternion.identity);
        }

        if (Random.Range(0, 2) > 0) {
            Instantiate(asteroid_Prefabs[Random.Range(0, asteroid_Prefabs.Length)], temp, Quaternion.identity);
        } else {
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], temp, Quaternion.identity);

        }
        Invoke("SpawnEnemies", timer);
    }
}
