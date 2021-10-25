using System.Collections;
using System;
using UnityEngine;

[Serializable]
public class IntList
{
    public int len;
    public int [] nb;
}

public class Spawner : MonoBehaviour
{
	public GameObject [] Enemy;
	private float timebtwspawn = 1.5f;
	private float timebtwspawnGroups;
	public float startTimeBtwSpawn;
	public float startTimeBtwSpawnGroups;
    public Vector3[] spawnPos;
    public IntList [] enemyType;
    private int indexPos = 0; // index for the position of the spawn
    private int currentIndex = -1; // index for the enemy type to spawn next
    private int currentYIndex = -1; // index for the enemy type to spawn next

    void Update()
    {
        if (timebtwspawn <= 0)
        {
            if (currentIndex == -1) {
                indexPos += 1;
                if (indexPos >= spawnPos.Length) {
                    indexPos = 0;
                }
                currentIndex = UnityEngine.Random.Range(0, enemyType.Length);
                currentYIndex = 0;
                timebtwspawnGroups = 0;
            }
            if (timebtwspawnGroups <= 0) {
                var newEnemy = Instantiate(Enemy[enemyType[currentIndex].nb[currentYIndex]], spawnPos[indexPos], Quaternion.identity);
                var scripts = newEnemy.GetComponent<EnemyMovement>();
                scripts.facingRight = true;
                timebtwspawnGroups = startTimeBtwSpawnGroups;
                currentYIndex += 1;
            } else {
                timebtwspawnGroups -= Time.deltaTime;
            }
            Debug.Log(currentYIndex);
            if (currentYIndex >= enemyType[currentIndex].len) {
                timebtwspawn = startTimeBtwSpawn;
                currentYIndex = -1;
                currentIndex = -1;
            }
        }
        else
        {
            timebtwspawn -= Time.deltaTime;
            // Debug.Log("time between spawn :");
            // Debug.Log(timebtwspawn);
        }
	}
}
