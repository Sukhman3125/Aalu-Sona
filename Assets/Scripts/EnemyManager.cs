using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EnemyType
{
    modi
}

public class EnemyManager : Singleton<EnemyManager>
{
    [Header("Enemy Spawn Settings")]
    public float SpawnRadius = 5f;
    public float minSpawnTime = 3f;
    public float maxSpawnTime = 10f;
    public int maxInstansiatedEnemies = 10;
    [Header("Enemy Settings")]
    public float enemySpeed = 2f;

    private List<GameObject> enemyList = new List<GameObject>();

    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    #region Enemy Spawning
    IEnumerator EnemySpawner()
    {
        enemyList.Clear();
        while (true)
        {
            while (enemyList.Count >= maxInstansiatedEnemies)
            {
                yield return null;
            }
            Vector2 dir = Random.insideUnitCircle.normalized; // random direction
            float radius = Random.Range(0.3f, 1f); // random distance

            Vector2 randPos = (Vector2)Movement.Instance.transform.position + dir * radius * SpawnRadius;

            var enemy = Instantiate(GameManager.Instance.prefabs.enemyPrefab,
                transform);
            var enemyScript = enemy.AddComponent<EnemyBehaviour>();
            enemyScript.enemyInit(EnemyType.modi);
            enemyList.Add(enemy);
            Vector3 spawnPos = new Vector3(randPos.x, enemy.transform.position.y, randPos.y);
            enemy.transform.position = spawnPos;
            float randTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randTime);
        }
    }
    #endregion
}
