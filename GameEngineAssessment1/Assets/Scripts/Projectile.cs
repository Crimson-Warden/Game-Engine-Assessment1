using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class Projectile : Collidable
{
    [SerializeField]
    bool playerOwned;
    public bool PlayerOwned
    {
        get
        {
            return playerOwned;
        }
        set
        {
            playerOwned = value;
            gameObject.layer = value ? 8 : 9;
        }
    }
    public float speed = 1;
    float timeToLive = 3;
    float currentLifeTime = 0;

    private void Start()
    {
        gameObject.layer = playerOwned ? 8 : 9;
    }

    void Update()
    {
        gameObject.transform.position += gameObject.transform.rotation * new Vector3(0, 1, 0) * Time.deltaTime * speed;
        currentLifeTime += Time.deltaTime;
        if (currentLifeTime >= timeToLive)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnContact(collision);
    }

    private void OnContact(Collider2D collision)
    {
        collision.gameObject.GetComponent<Collidable>().TakeDamage(damage);
        Destroy(gameObject);
    }
}