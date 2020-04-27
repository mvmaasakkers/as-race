using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyCar;
    public int enemyCount = 0;

    public int maxEnemies = 3;

    float lane1 = -2f;
    float lane2 = 0f;
    float lane3 = 2f;

    float spawnpointY = 6f;

    void Update()
    {
        if (enemyCount < maxEnemies)
        {
            addEnemy(lane1);
            addEnemy(lane2);
            addEnemy(lane3);
        }
    }

    void addEnemy(float x)
    {
        enemyCount += 1;
        GameObject c = Instantiate(enemyCar, new Vector2(x, spawnpointY), Quaternion.identity);
        c.GetComponent<EnemyCar>().movementSpeed = Random.Range(1f, 2f);
    }
}
