using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawner : MonoBehaviour
{
    public List<GameObject> EnemyPrefabs = new List<GameObject>();

    public float SpawnRate = 5;
    private float lastSpawn = 0;
    public GameObject Target;

    private List<GameObject> zombieQueue = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lastSpawn + SpawnRate < Time.fixedTime)
        {
            GameObject enemy = Instantiate(EnemyPrefabs[0], transform.position, Quaternion.identity);
            enemy.GetComponent<NavMeshAgent>().SetDestination(Target.transform.position);
            lastSpawn = Time.fixedTime;

            zombieQueue.Add(enemy);
        }
    }
    public void ZombieDeath(GameObject zombie)
    {
        if (zombieQueue.Contains(zombie))
        {
            zombieQueue.Remove(zombie);
        }
    }   
    public GameObject GetNextZombie(GameObject zombie)
    {
        GameObject nextZombie = null;
        if (!zombie && zombieQueue.Count > 0) nextZombie = zombieQueue[0];
        else if (zombieQueue.Contains(zombie))
        {
            int index = zombieQueue.IndexOf(zombie);
            if(zombieQueue.IndexOf(zombie) < zombieQueue.Count - 2)
            {
                nextZombie = zombieQueue[index + 1];
            }
        }
        return nextZombie;
    }
}
