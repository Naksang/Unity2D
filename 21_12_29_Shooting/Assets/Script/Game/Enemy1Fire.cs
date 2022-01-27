using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Fire : MonoBehaviour
{
    public GameObject _enemyfire;
    public Transform _firepos;

    [SerializeField]
    float _createTime = 1.5f;
    float _initTime;

    void Start()
    {

    }

    void Update()
    {
        _initTime += Time.deltaTime;

        if (_initTime > _createTime)
        {
            GameObject fire = Instantiate(_enemyfire);
            Destroy(fire, 5.0f);
            fire.transform.position = _firepos.position;

            _initTime = 0;
        }
    }
}
