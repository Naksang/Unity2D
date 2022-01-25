using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BulletWaitMove : MonoBehaviour
{
    public Transform _enemy;

    public Transform _player;

    public float _speed = 10f;

    bool _trs = false;

    Vector3 _dir;

    void Start()
    {
        Destroy(gameObject, 2f);
        _enemy = GameObject.Find("Enemy").transform.GetChild(0);
        _player = GameObject.Find("Player").transform;

        _dir = _player.position - this.transform.position;
        _dir.Normalize();
    }

    void Update()
    {
        if (!_trs)
            transform.Translate(Vector2.right * _speed * Time.deltaTime, Space.Self);
        else
            this.transform.position += _dir * _speed * Time.deltaTime;

        if (Vector2.Distance(this.transform.position, _enemy.position) >= 1.0f)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (Vector2.Distance(this.transform.position, _enemy.position) >= 5.0f)
        {
            StartCoroutine(TransChange());
        }
    }

    IEnumerator TransChange()
    {
        _trs = true;
        yield return new WaitForSeconds(1.0f);
    }
}
