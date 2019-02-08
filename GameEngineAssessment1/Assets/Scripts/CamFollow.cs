using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CamFollow : MonoBehaviour
{
    [SerializeField]
    GameObject objectToFollow;

    void Start()
    {

    }

    void Update()
    {
        gameObject.transform.position = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, -10);
    }
}
