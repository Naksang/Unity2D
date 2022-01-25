using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BulletMove : MonoBehaviour
{
    public Transform _enemy;

    public float _speed = 3.0f;

    void Start()
    {
        Destroy(gameObject, 2.0f);
        _enemy = GameObject.Find("Enemy").transform.GetChild(0);
    }

    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime, Space.Self);

        if (Vector2.Distance(this.transform.position, _enemy.position) >= 1.0f)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
