using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    public GameObject _fly_right;
    public GameObject _fly_left;
    bool fold_r = false;
    bool fold_l = false;

    SpriteRenderer _rend;

    float _speed = 5.0f;
    float _hp;
    bool _die;

    Vector3 dir;

    void Start()
    {
        _fly_right = this.transform.GetChild(1).transform.GetChild(0).gameObject;
        _fly_left = this.transform.GetChild(1).transform.GetChild(1).gameObject;

        _rend = this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        dir = Vector3.down;
        _hp = 15;
        _die = false;
    }

    void Update()
    {
        if (_die) return;

        if (_hp <= 0)
        {
            Destroy(this.gameObject);

            GameObject.Find("GameManager").GetComponent<GameManager>().Score += 100;
            _die = true;
        }
        else if ( _hp > 0)
        {
            this.transform.Translate(dir * _speed * Time.deltaTime);
            FlyAnimation();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerFire"))
        {
            _hp -= collision.gameObject.GetComponent<FireMove>().Damege;
            Destroy(collision.gameObject);
            StartCoroutine(ChangeColor());
        }
    }

    void FlyAnimation()
    {
        if (!fold_l || !fold_r)
        {
            if (_fly_left.transform.rotation.z > 50) fold_l = true;
            else
            {
                _fly_left.transform.Rotate(new Vector3(0, 0, 100 * Time.deltaTime));
            }
            if (_fly_right.transform.localScale.z < -50) fold_r = true;
            else
            {
                _fly_right.transform.Rotate(new Vector3(0, 0, -100 * Time.deltaTime));
            }
        }
        else
        {
            if (_fly_left.transform.localScale.z <= 0) fold_l = false;
            else
            {
                _fly_left.transform.Rotate(new Vector3(0, 0, -100 * Time.deltaTime));
            }
            if (_fly_right.transform.localScale.z >= 0) fold_r = false;
            else
            {
                _fly_right.transform.Rotate(new Vector3(0, 0, 100 * Time.deltaTime));
            }
        }
    }

    IEnumerator ChangeColor()
    {
        _rend.color = new Color(1, 0, 0, 1);

        yield return new WaitForSeconds(0.05f);

        _rend.color = new Color(1, 1, 1, 1);
    }
}
