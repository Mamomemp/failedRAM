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
            // Speichere die Position des zerstörten Objekts
            Vector3 spawnPosition = collision.gameObject.transform.position;

            Destroy(collision.gameObject); // Zerstört das kollidierende Objekt
            Destroy(gameObject); // Zerstört das aktuelle Objekt, an dem dieses Skript angebracht ist

            // Instanziere ein neues Partikelsystem-Prefab an der gespeicherten Position
            GameObject explosion = Instantiate(explosionPrefab, spawnPosition, Quaternion.identity);
            // Zerstöre das Partikelsystem nach einer bestimmten Zeit (z. B. Dauer der Partikel)
            Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.duration);
        }
        else if (collision.gameObject.CompareTag("Delete_Projektile"))
        {

            Destroy(gameObject); // Zerstört das aktuelle Objekt, an dem dieses Skript angebracht ist
        }
    }
}
