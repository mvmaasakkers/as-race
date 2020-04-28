using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyCar;
    public GameObject player;

    public int enemyCount = 0;
    public int maxEnemies = 2;
    
    public float[] lanes;

    float spawnpointY = 6f;

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemyCount -= 1;
    }

    void Update()
    {
        if (enemyCount == 0)
        {
            int i = Random.Range(0, lanes.Length);
            addEnemy(lanes[i]);
        }
    }

    void addEnemy(float x)
    {
        enemyCount += 1;
        GameObject c = Instantiate(enemyCar, new Vector2(x, spawnpointY), Quaternion.identity);
        c.GetComponent<EnemyCar>().player = player;
        c.GetComponent<EnemyCar>().movementSpeed = Random.Range(1f, 2f);
    }
}
