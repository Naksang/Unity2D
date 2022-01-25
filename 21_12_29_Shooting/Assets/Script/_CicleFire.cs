using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CicleFire : MonoBehaviour
{ 
    public GameObject _bullet;

    bool make = true;

    private void Update()
    {
        if(make)
        {
            for (int i = 0; i < 360; i += 13)
            {
                GameObject bullet = Instantiate(_bullet);

                Destroy(bullet, 2f);

                bullet.transform.position = this.transform.position;

                bullet.transform.rotation = Quaternion.Euler(0, 0, i);
            }

            make = false;
            StartCoroutine(MakeCircle());
        }
    }

    IEnumerator MakeCircle()
    {
        yield return new WaitForSeconds(0.5f);
        make = true;
    }
}
