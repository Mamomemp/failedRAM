using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    private Vector3 spawnPosition;
    [SerializeField] private float xRotation;
    [SerializeField] private float yRotation;
    [SerializeField] private float zRotation;

    [SerializeField] private int derzeitigeElement = 0;
    public List<Vector3> transformList;
    public void SpawnBullet()
    {
        if (derzeitigeElement < transformList.Count)
        {
            spawnPosition = transformList[derzeitigeElement];
            derzeitigeElement++;
        }
        else
        {
            derzeitigeElement = 0;
        }

        GameObject bullet = bulletPool.GetBullet();

        bullet.transform.position = spawnPosition;
        bullet.transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);


    }
}

