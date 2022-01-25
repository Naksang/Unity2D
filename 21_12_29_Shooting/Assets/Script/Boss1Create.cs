using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Create : MonoBehaviour
{
    public Transform _createPos;

    public GameObject _enemySource;

    GameObject _boss = null;


    bool _makeboss = false;

    GameObject[] _enemy;
    GameObject[] _bullet;

    public GameObject _coin;

    private void OnEnable()
    {
        _makeboss = false;

        _enemy = GameObject.FindGameObjectsWithTag("Enemy");
        _bullet = GameObject.FindGameObjectsWithTag("EnemyFire");

        _boss = Instantiate(_enemySource);
        _boss.transform.position = this.transform.position;
    }

    void Update()
    {
        if(!_makeboss)
        {
            for (int i = 0; i < _enemy.Length; i++)
            {
                GameObject coin = Instantiate(_coin);
                coin.transform.position = _enemy[i].transform.position;
                Destroy(_enemy[i]);
            }

            for (int i = 0; i < _bullet.Length; i++)
            {
                GameObject coin = Instantiate(_coin);
                coin.transform.position = _bullet[i].transform.position;
                Destroy(_bullet[i]);
            }

            _makeboss = true;
        }

        else
        {
            if (_boss.transform.position.y > 3.0f)
            {
                _boss.transform.Translate(Vector3.down * 2.0f * Time.deltaTime);
            }
        }
    }
}
