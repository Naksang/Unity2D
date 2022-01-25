using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _RotFire : MonoBehaviour
{
    public float _speed;

    public Transform _enemy;

    public GameObject _bullet;

    void Update()
    {
        transform.Rotate(Vector3.forward * _speed * 100 * Time.deltaTime);

        GameObject bullet = Instantiate(_bullet);

        Destroy(bullet, 2f);

        bullet.transform.position = this.transform.position;

        bullet.transform.rotation = this.transform.rotation;
    }
}
