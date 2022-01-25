using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Fire : MonoBehaviour
{
    public GameObject _enemyfire;
    public Transform _firepos;
    bool _startfire = false;

    float _initTime;
    float _createTime = 1.5f;

    void Start()
    {
        StartCoroutine(EnemyFire());
    }

    IEnumerator EnemyFire()
    {
        yield return new WaitForSeconds(0.5f);
        _startfire = true;
    }

    void Update()
    {
        _initTime += Time.deltaTime;

        if (_startfire)
        {
            if (_initTime > _createTime)
            {
                GameObject fire = Instantiate(_enemyfire);
                Destroy(fire, 5.0f);
                fire.transform.position = _firepos.position;

                _initTime = 0;
            }
        }
    }
}
