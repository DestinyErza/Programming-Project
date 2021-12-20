using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{
    OneHand,
    TwoHand
}
public enum PatrolType
{
    Patrol,
    Detect,
    Chase,
    Attack
}
public class EnemyManager : Singleton<EnemyManager>
{
  
    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;
    public List<GameObject> enemies;
    public GameObject player;
    public float spawnDelay = 2f;
    public int maxEnemies = 3;


    public PatrolType patrolType;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //  SpawnEnemy();
     //S   StartCoroutine(SpawnWithDelay());

    }
    IEnumerator SpawnWithDelay()
    {
        // Debug.Log("aaaa");
        //spawn randm enemy
        int rndEnemy = Random.Range(0, enemyTypes.Length);
        //randm spawn
        int rndSpawn = Random.Range(0, spawnPoints.Length);
        //insantiate enemy at random spawn
        GameObject enemy = Instantiate(enemyTypes[rndEnemy], spawnPoints[rndSpawn].position, spawnPoints[rndSpawn].rotation);
        //add enemy to list
        enemies.Add(enemy);
        //update the UI with new count score
        _UI.UpdateEnemyCount(enemies.Count);
        //wait for delay
        yield return new WaitForSeconds(spawnDelay);
        //run again
        if (enemies.Count <= maxEnemies)
            StartCoroutine(SpawnWithDelay());

    }



    void Despawn()
  {
    //if count goes below 0 return
    if (enemies.Count == 0)
        return;

    Destroy(enemies[0]);
    enemies.RemoveAt(0);

  }
    void KillEnemy(GameObject _enemy)
    {
        Destroy(_enemy);
        enemies.Remove(_enemy);
       _UI.UpdateEnemyCount(enemies.Count);
    }

    private void OnEnable()
    {
        GameEvents.OnEnemyDied += KillEnemy;
    }
    private void OnDisable()
    {
        GameEvents.OnEnemyHit -= KillEnemy;
    }
}
