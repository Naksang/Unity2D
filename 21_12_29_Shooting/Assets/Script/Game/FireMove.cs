using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    Vector3 dir;

    float _damege = 1.0f;
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
