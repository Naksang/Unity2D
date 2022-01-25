using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BloommingFire : MonoBehaviour
{
    public GameObject _bullet;

    int _pos = 0;

    float _initTime;
    float _createTime = 0.01f;

    void Update()
    {
        _initTime += Time.deltaTime;
        if(_initTime > _createTime)
        {
            for (int i = 0; i < 360; i += 90)
            {
                GameObject bullet1 = Instantiate(_bullet);

                Destroy(bullet1, 2f);

                bullet1.transform.position = this.transform.position;

                bullet1.transform.rotation = Quaternion.Euler(0, 0, i + _pos);


                GameObject bullet2 = Instantiate(_bullet);

                Destroy(bullet2, 2f);

                bullet2.transform.position = this.transform.position;

                bullet2.transform.rotation = Quaternion.Euler(0, 0, i - _pos);

                _pos++;
            }

            _initTime = 0;
        }
    }
}
