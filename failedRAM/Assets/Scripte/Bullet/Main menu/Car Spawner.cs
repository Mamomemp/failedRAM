using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> carObjectList;
    [SerializeField] private List<Vector3> spawnPositionList;
    [SerializeField] private Quaternion quaternion;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnObject();
        }
    }

    // Randomly spawn an object from the lists
    public void SpawnObject()
    {
        int randomCarIndex = PickRandom(carObjectList);
        int randomSpawnIndex = PickRandom(spawnPositionList);

        GameObject car = Instantiate(carObjectList[randomCarIndex], spawnPositionList[randomSpawnIndex], quaternion);
        car.SetActive(true);

    }

    private int PickRandom<T>(List<T> list)
    {
        int randomIndex = Random.Range(0, list.Count);
        return randomIndex;
    }
}

