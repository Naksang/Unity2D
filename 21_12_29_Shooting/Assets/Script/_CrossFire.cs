using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CrossFire : MonoBehaviour
{
    public GameObject _bullet;

    void Update()
    {
        for (int i = 0; i < 360; i += 45)
        {

            GameObject bullet = Instantiate(_bullet);

            Destroy(bullet, 2f);

            bullet.transform.position = this.transform.position;

            bullet.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }
}
