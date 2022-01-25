using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Create : MonoBehaviour
{
    float _createTime = 10.0f;
    float _initTime;

    public Transform _createPos;

    public GameObject _enemySource;

    void Update()
    {
        _initTime += Time.deltaTime;
        if (_initTime > _createTime)
        {
            GameObject enemy = Instantiate(_enemySource);
            Destroy(enemy, 10.0f);
            enemy.transform.position = _createPos.position;
           
            _initTime = 0;
        }
    }
}
