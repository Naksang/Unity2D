using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGoffset : MonoBehaviour
{
    public GameObject _star0;
    public GameObject _star1;

    float _speed = 2.0f;

    Vector3 dir;

    void Start()
    {
        dir = Vector3.down;
    }

    void Update()
    {
        _star0.transform.Translate(dir * _speed * Time.deltaTime);
        _star1.transform.Translate(dir * _speed * Time.deltaTime);

        if(_star0.transform.position.y < -10.0f)
        {
            _star0.transform.position = new Vector3(0, 10.0f, 0);
        }
        else if (_star1.transform.position.y < -10.0f)
        {
            _star1.transform.position = new Vector3(0, 10.0f, 0);
        }
    }
}
