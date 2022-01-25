using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreateManager : MonoBehaviour
{
    Enemy1Create _enemy1;
    Enemy2Create _enemy2;
    MeteorCreate _meteor;
    Boss1Create _boss1;

    GameManager _gm;

    private void Awake()
    {
        _enemy1 = this.GetComponent<Enemy1Create>();
        _enemy2 = this.GetComponent<Enemy2Create>();
        _meteor = this.GetComponent<MeteorCreate>();
        _boss1 = this.GetComponent<Boss1Create>();

        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(_gm.Score != 0 && _gm.Score % 500 == 0)
        {
            _enemy1.enabled = false;
            _enemy2.enabled = false;
            //_meteor.enabled = false;

            _boss1.enabled = true;
        }
    }
}
