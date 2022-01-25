using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Create : MonoBehaviour
{
    float _createTime = 0.5f;
    float _initTime;

    public Transform[] _createPos;

    public GameObject _enemySource;

    void Update()
    {
        _initTime += Time.deltaTime;
        if(_initTime > _createTime)
        {
            int rand = Random.Range(0, 4);

            if(rand == 3)
            {
                GameObject enemy = Instantiate(_enemySource);
                Destroy(enemy, 10.0f);
                enemy.transform.position = _createPos[rand].position;
            }
            else
            {
                int rand2 = 6 - rand;
                GameObject enemy0 = Instantiate(_enemySource);
                Destroy(enemy0, 10.0f);
                enemy0.transform.position = _createPos[rand].position;

                GameObject enemy1 = Instantiate(_enemySource);
                Destroy(enemy1, 10.0f);
                enemy1.transform.position = _createPos[rand2].position;
            }
            _initTime = 0;
        }
    }
}
