using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : MonoBehaviour
{
    float _speed = 5.0f;

    Vector3 dir;

    float _damege = 5.0f;
    public float Damege { get { return _damege; } }


    void Start()
    {
        dir = Vector3.up;
    }

    void Update()
    {
        this.transform.Translate(dir * _speed * Time.deltaTime);
    }
}
