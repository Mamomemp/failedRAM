using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int spieler_leben;
    public GameObject Spieler_Object;

    public float dead_delay;
    public float grace_period = 1f;
    private float letzter_treffer;

    private void Start()
    {
        letzter_treffer = Time.time - grace_period;   
    }

    // Update is called once per frame
    void Update()
    {
        if (spieler_leben <= 0) 
        {
            Destroy(Spieler_Object, dead_delay);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("schaedlich") && Time.time - letzter_treffer > grace_period) 
        {
            damage_nehmen(1);
            letzter_treffer = Time.time;
        }
    }

    private void damage_nehmen(int damage) 
    {
        spieler_leben -= damage;
    }
}
