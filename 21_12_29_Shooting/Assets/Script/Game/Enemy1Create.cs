using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Create : MonoBehaviour
{
    float _createTime = 1.5f;
    float _initTime;

    public Transform[] _createPos;
    public GameObject _enemySource;

    void Update()
    {
        _initTime += Time.deltaTime;
        if(_initTime > _createTime)
        {
            int rand = Random.Range(0, 7);

            for(int i = 0; i < 7; i++)
            {
                if (i == rand) continue;

                GameObject Enemy = Instantiate(_enemySource);
                Destroy(Enemy, 10.0f);
                Enemy.transform.position = _createPos[i].position;
            }

            _initTime = 0;
        }
    }
}
