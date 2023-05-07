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


    public List<Vector3> transformList;
    public int derzeitigeElement = 0;
    public void SpawnBullet()
    {
        spawnPosition = transformList[derzeitigeElement];
        derzeitigeElement++;

        GameObject bullet = bulletPool.GetBullet();

        bullet.transform.position = spawnPosition;
        bullet.transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);


    }
}

