using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrasher : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private bool toCollect;
    [SerializeField] private GameManager gamemanager;

    private float speed = 1.5f;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 spawnPosition = collision.gameObject.transform.position;

        if (collision.gameObject.CompareTag("schaedlich"))
        {
            Destroy(collision.gameObject); 
            Destroy(transform.parent.gameObject);

            GameObject explosion = Instantiate(explosionPrefab, spawnPosition, Quaternion.identity);
            Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.duration);
        }
        else if (collision.gameObject.CompareTag("Player") && toCollect == true) // COllectables
        {
            GameObject collection = Instantiate(explosionPrefab, spawnPosition, Quaternion.identity);
            collection.GetComponent<ParticleSystem>().GetComponent<Renderer>().material.color = Color.cyan; //Set color to green
            
            //Makes the particleSystem quicker
            ParticleSystem particleSystem = collection.GetComponent<ParticleSystem>();
            var main = particleSystem.main;
            main.startSpeed = new ParticleSystem.MinMaxCurve(speed);

            
            Destroy(collection, collection.GetComponent<ParticleSystem>().main.duration);
            Destroy(transform.parent.gameObject);
            gamemanager.counter_IntToWin();
        }
        else if (collision.gameObject.CompareTag("Delete_Projektile"))
        {

            Destroy(transform.parent.gameObject);
        }
    }
}
