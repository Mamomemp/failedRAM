using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int max_spieler_leben;
    private int spieler_leben;
    [SerializeField] private GameObject Spieler_Object;

    [SerializeField] private Optional<HealthBar> healthBar;
    [SerializeField] private Optional<ObjektPulser> objektPulser;
    
    [SerializeField] private float dead_delay;
    [SerializeField] private float grace_period = 1f;
    private float letzter_treffer;

    [SerializeField] private GameManager gameManager;
    void Start()
    {
        spieler_leben = max_spieler_leben;
        if (healthBar.Value != null)
        {
            healthBar.Value.SetMaxHealth(max_spieler_leben);
        }
        letzter_treffer = Time.time - grace_period;
    }

    // Update is called once per frame
    void Update()
    {
        if (spieler_leben <= 0)
        {
            Destroy(Spieler_Object, dead_delay);

            // Call the LoseGame method in GameManager
            gameManager.LoseGame();
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
        objektPulser.Value.Pulse();
        spieler_leben -= damage;
        healthBar.Value.SetHealth(spieler_leben);
    }
}
