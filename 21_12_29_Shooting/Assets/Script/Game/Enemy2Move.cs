using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Move : MonoBehaviour
{
    float _speed = 2.0f;
    float _hp = 15;
    public GameObject _item;
    SpriteRenderer _rend;

    bool _cbHome;

    void Start()
    {
        _rend = this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        _cbHome = false;
    }

    void Update()
    {
        if (_hp <= 0)
        {
            GameObject item = Instantiate(_item);
            item.transform.position = this.transform.position;
            Destroy(this);
        }
        if (_cbHome)
        {
            this.transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }
        else
        {
            if (this.transform.position.y > 3.0f)
            {
                this.transform.Translate(Vector3.down * _speed * Time.deltaTime);
            }
            else if (this.transform.position.y <= 3.0f)
            {
                StartCoroutine(DeleyTime());
            }
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

    IEnumerator DeleyTime()
    {
        yield return new WaitForSeconds(2.5f);

        _cbHome = true;
    }
}
