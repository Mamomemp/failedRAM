using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrasher : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("schaedlich"))
        {
            Destroy(collision.gameObject); // Zerstoert das kollidierende Objekt
            Destroy(gameObject); // Zerstoert das aktuelle Objekt, an dem dieses Skript angebracht ist
        }else if (collision.gameObject.CompareTag("Delete_Projektile"))
        {
            Destroy(gameObject);
        }
    }
}
