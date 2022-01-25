using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    public Animator _animater;
    SpriteRenderer _rend;

    float _speed = 2.0f;
    float _hp;
    bool _die;

    Vector3 dir;

    void Start()
    {
        _animater = GetComponentInChildren<Animator>();
        _rend = this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        dir = Vector3.down;
        _hp = 15;
        _die = false;
    }

    void Update()
    {
        if (_die) return;
        if(_hp <= 0)
        {
            _animater.SetBool("expl", true);
            _animater = null;

            this.GetComponent<Enemy1Fire>().enabled = false;
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

            Transform fire = this.transform.GetChild(0).transform.GetChild(0);

            fire.gameObject.SetActive(false);

            GameObject.Find("GameManager").GetComponent<GameManager>().Score += 100;
            _die = true;
        }
        else if ( _hp > 0)
        {
            this.transform.Translate(dir * _speed * Time.deltaTime);
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

    IEnumerator ChangeColor()
    {
        _rend.color = new Color(1, 0, 0, 1);

        yield return new WaitForSeconds(0.05f);

        _rend.color = new Color(1, 1, 1, 1);
    }
}
