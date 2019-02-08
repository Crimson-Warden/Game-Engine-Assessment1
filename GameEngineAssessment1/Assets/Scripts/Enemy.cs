using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class Enemy : Collidable {
    [SerializeField]
    DamageNumber damageNum;
    // Use this for initialization
    void Start()
    {
        Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            damageNum.gameObject.SetActive(true);
            damageNum.transform.position = FindObjectOfType<Camera>().WorldToScreenPoint(gameObject.transform.position);
            Destroy(gameObject);
        }
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        DamageNumber dn = Instantiate(damageNum, damageNum.GetComponentInParent<Canvas>().transform, true);
        float rand = Random.Range(-1f, 1f);
        dn.transform.position = gameObject.transform.position;
        dn.transform.position += new Vector3(rand, 0);
        dn.SetActive(true);
        if (currentHealth <= 0)
            Destroy(gameObject);
    }
}
