using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projektil : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] private BulletPool bulletPool;

    [SerializeField] float _maxLebensZeit;
    private float _lebensZeit;

    private void Start()
    {
        _lebensZeit = _maxLebensZeit;
    }
    public void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;

       /* _lebensZeit -= Time.deltaTime;
        if (_lebensZeit <= 0f)
        {
            bulletPool.ReturnBullet(gameObject);
        }*/
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Lösche_Projektil" && LayerMask.LayerToName(collision.gameObject.layer) == "Barriere")
        {
            bulletPool.ReturnBullet(gameObject);
        }
    }
    
}
