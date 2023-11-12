using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RandomObjectSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> carObjectList;
    [SerializeField] private List<Vector3> spawnPositionList;
    [SerializeField] private float initialSpawnDelay = 2.0f;
    [SerializeField] private float minSpawnFrequency = 1.0f;
    [SerializeField] private float maxSpawnFrequency = 0.5f;
    [SerializeField] private bool startSpawning;

    private float nextSpawnTime;
    private float timeSinceLastSpawn;
    private InputSystem inputSystem;

    #region SetstartSpawing
    private void Awake()
    {
        inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        inputSystem.Menu.Enable();
        inputSystem.Menu.Horizontal.performed += HorizontalPerformed;
    }
    private void OnDisable()
    {
        inputSystem.Menu.Disable();
        inputSystem.Menu.Horizontal.performed -= HorizontalPerformed;
    }
    private void HorizontalPerformed(InputAction.CallbackContext context)
    {
        startSpawning = true;
    }

    #endregion

    private void Start()
    {
        nextSpawnTime = initialSpawnDelay;
        startSpawning = false;
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= nextSpawnTime && startSpawning)
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
