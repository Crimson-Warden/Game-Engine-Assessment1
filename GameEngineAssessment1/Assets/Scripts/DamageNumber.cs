using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

class DamageNumber : Text
{
    [SerializeField]
    float timeToExpire = 0.5f;
    float timer = 0;

    public void SetActive(bool isActive)
    {
        timer = 0;
        gameObject.SetActive(isActive);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        gameObject.transform.position += new Vector3(0, 0.01f);
        if (timer >= timeToExpire)
            Destroy(gameObject);
    }
}
