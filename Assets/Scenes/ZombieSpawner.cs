using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zombiePrefab;
    public int zombieCount = 10;
    public Transform[] spawnLocation;
    public float spawnRate = 1f;
    private float nextspawn = 0.0f;
    private Queue<GameObject> zombiePool = new Queue<GameObject>();
    private void Start()
    {
        for (int i = 0; i < zombieCount; i++)
        {
            GameObject zombie = Instantiate(zombiePrefab);
            zombie.SetActive(false);
            zombiePool.Enqueue(zombie);
        }
    }
    private void Update()
    {
        if (Time.time > nextspawn)
        {
            nextspawn = Time.time + spawnRate;
            SpawnZombie(); 
        }
    }
    void SpawnZombie()
    {
        if (zombiePool.Count == 0) return;
        GameObject zombie = zombiePool.Dequeue();
        zombie.transform.position = spawnLocation[Random.Range(0, spawnLocation.Length)].position;
        zombie.SetActive(true);
    }
    public void ZombieDied(GameObject zombie)
    {
        zombie.SetActive(false);
        zombiePool.Enqueue(zombie);
    }
}
