using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> carObjectList;
    [SerializeField] private List<Vector3> spawnPositionList;
    [SerializeField] private float initialSpawnDelay = 2.0f;
    [SerializeField] private float minSpawnFrequency = 1.0f;
    [SerializeField] private float maxSpawnFrequency = 0.5f;

    private float nextSpawnTime;
    private float timeSinceLastSpawn;

    private void Start()
    {
        nextSpawnTime = initialSpawnDelay;
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= nextSpawnTime)
        {
            SpawnObject();
            timeSinceLastSpawn = 0f;

            // Calculate the next spawn time with increasing frequency
            float randomFrequency = Random.Range(minSpawnFrequency, maxSpawnFrequency);
            nextSpawnTime = randomFrequency;
        }
    }

    // Randomly spawn an object from the lists
    public void SpawnObject()
    {
        int randomCarIndex = PickRandom(carObjectList);
        int randomSpawnIndex = PickRandom(spawnPositionList);

        GameObject car = Instantiate(carObjectList[randomCarIndex], spawnPositionList[randomSpawnIndex], Quaternion.identity);
        car.SetActive(true);
    }

    private int PickRandom<T>(List<T> list)
    {
        int randomIndex = Random.Range(0, list.Count);
        return randomIndex;
    }
}
