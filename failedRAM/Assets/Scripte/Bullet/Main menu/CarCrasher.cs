using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrasher : MonoBehaviour
{
    public GameObject explosionPrefab; // Das Prefab des Partikelsystems

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("schaedlich"))
        {
            // Speichere die Position des zerst�rten Objekts
            Vector3 spawnPosition = collision.gameObject.transform.position;

            Destroy(collision.gameObject); // Zerst�rt das kollidierende Objekt
            Destroy(gameObject); // Zerst�rt das aktuelle Objekt, an dem dieses Skript angebracht ist

            // Instanziere ein neues Partikelsystem-Prefab an der gespeicherten Position
            GameObject explosion = Instantiate(explosionPrefab, spawnPosition, Quaternion.identity);
            // Zerst�re das Partikelsystem nach einer bestimmten Zeit (z. B. Dauer der Partikel)
            Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.duration);
        }
        else if (collision.gameObject.CompareTag("Delete_Projektile"))
        {

            Destroy(gameObject); // Zerst�rt das aktuelle Objekt, an dem dieses Skript angebracht ist
        }
    }
}
