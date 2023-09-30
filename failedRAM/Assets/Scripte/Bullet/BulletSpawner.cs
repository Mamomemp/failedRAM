using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private BulletPool indPool;
    private Vector3 spawnPosition;
    [SerializeField] private float xRotation;
    [SerializeField] private float yRotation;
    [SerializeField] private float zRotation;

    [SerializeField] private int bulletElement = 0;
    [SerializeField] private int indElement = 0;
    [SerializeField] private bool printBullets = false;

    public List<Vector3> transformList;

    public void spawnBullet()
    {
        Spawn(bulletPool, ref bulletElement);
        if (printBullets == true)
        {
            if (bulletElement < transformList.Count)
            {
                print(bulletElement + " " + transformList[bulletElement]);
            }
            else
            {
                print("No more :D");
            }
        }
    }

    public void spawnInd()
    {
        Spawn(indPool, ref indElement);
    }
    public void Spawn(BulletPool bP, ref int derzeitigeElement)
    {
        if (derzeitigeElement < transformList.Count)
        {
            spawnPosition = transformList[derzeitigeElement];
            derzeitigeElement++;
        }
        else
        {
           // derzeitigeElement = 0;
       
           
        }

        GameObject bullet = bP.GetBullet();

        bullet.transform.position = spawnPosition;
        bullet.transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);


    }
}

