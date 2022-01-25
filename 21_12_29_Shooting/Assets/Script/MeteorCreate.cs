using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCreate : MonoBehaviour
{
    float _createTime = 5.0f;
    float _initTime;

    public Transform[] _createPos;

    public GameObject _enemySource;

    void Update()
    {
        _initTime += Time.deltaTime;
        if (_initTime > _createTime)
        {
            int rand = Random.Range(0, 2);

            GameObject enemy = Instantiate(_enemySource);
            Destroy(enemy, 10.0f);
            enemy.transform.position = _createPos[rand].position;

            _initTime = 0;
        }
    }
}
