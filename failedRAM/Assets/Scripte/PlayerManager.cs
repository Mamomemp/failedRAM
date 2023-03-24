using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] int max_spieler_leben;
    private int spieler_leben;
    [SerializeField] GameObject Spieler_Object;

    [SerializeField] HealthBar healthBar;
    [SerializeField] ObjektPulser objektPulser;
    [SerializeField] GameOverScreen gameOverScreen;

    [SerializeField] float dead_delay;
    [SerializeField] float grace_period = 1f;
    private float letzter_treffer;

    void Start()
    {
        spieler_leben = max_spieler_leben;
        healthBar.SetMaxHealth(max_spieler_leben);
        letzter_treffer = Time.time - grace_period;   
    }

    // Update is called once per frame
    void Update()
    {
        if (spieler_leben <= 0) 
        {
            Destroy(Spieler_Object, dead_delay);
            gameOverScreen.GameOverScreen_toggle();
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
        objektPulser.Pulse();
        spieler_leben -= damage;
        healthBar.SetHealth(spieler_leben);
    }
}
