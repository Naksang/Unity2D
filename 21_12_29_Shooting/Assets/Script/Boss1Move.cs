using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1Move : MonoBehaviour
{
    public Animator _animater;
    public float _maxHp;
    public float _hp;
    bool _die = false;
    public Slider _hpBar;

    SpriteRenderer _rend;

    public Vector3[] _patrolPos;
    float _speed = 2.0f;
    public int _nowpos = 1;


    void Start()
    {
        _maxHp = 100;
        _hp = _maxHp;
        _rend = this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();

        _patrolPos[0] = this.transform.position;
        _patrolPos[1] = new Vector3(-2, 1, 0);
    }

    void Update()
    {
        if (_die) return;
        if (_hp <= 0)
        {
            _animater.SetBool("expl", true);
            _animater = null;

            this.GetComponent<Enemy1Fire>().enabled = false;
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

            GameObject.Find("GameManager").GetComponent<GameManager>().Score += 600;

            GameObject cz = GameObject.Find("CreateZone");
            cz.GetComponent<Enemy1Create>().enabled = true;
            cz.GetComponent<Enemy2Create>().enabled = true;
            //cz.GetComponent<MeteorCreate>().enabled = true;
            cz.GetComponent<Boss1Create>().enabled = false;

            Destroy(this.gameObject);


        }
        else if (_hp > 0)
        {
            _hpBar.value = _hp / _maxHp;

            if(_nowpos == 0)
            {
                if (Vector2.Distance(this.transform.position, _patrolPos[0]) < 0.01f)
                {
                    StartCoroutine(StopDeley());
                    _nowpos = 1;
                }
                else
                    this.transform.position = Vector3.MoveTowards(transform.position, _patrolPos[0], _speed * Time.deltaTime);
            }
            else if(_nowpos == 1)
            {
                if (Vector2.Distance(this.transform.position, _patrolPos[1]) < 0.01f)
                {
                    StartCoroutine(StopDeley());
                    _nowpos = 0;
                }
                else
                    this.transform.position = Vector3.MoveTowards(transform.position, _patrolPos[1], _speed * Time.deltaTime);
            }

            //switch(_nowpos)
            //{
            //    case 0:
            //        {
            //            if (Vector2.Distance(this.transform.position, _patrolPos[0]) < 0.01f)
            //            {
            //                StartCoroutine(StopDeley());
            //                _nowpos = 1;
            //            }
            //            else
            //                this.transform.position = Vector3.MoveTowards(transform.position, _patrolPos[0], _speed * Time.deltaTime);
            //        }
            //        break;
            //    case 1:
            //        {
            //            if (Vector2.Distance(this.transform.position, _patrolPos[1]) < 0.01f)
            //            {
            //                StartCoroutine(StopDeley());
            //                _nowpos = 0;
            //            }
            //            else
            //                this.transform.position = Vector3.MoveTowards(transform.position, _patrolPos[1], _speed * Time.deltaTime);
            //        }
            //        break;
            //}
        }
    /*
        MoveTowards
        SmoothDamp
        Lerp
        Slerp
    */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerFire"))
        {
            if (_hp > 0)
            {
                _hp -= collision.gameObject.GetComponent<FireMove>().Damege;
                Debug.Log(_hp);
                Destroy(collision.gameObject);

                StartCoroutine(ChangeColor());
            }
        }
    }

    IEnumerator ChangeColor()
    {
        _rend.color = new Color(1, 0, 0, 1);

        yield return new WaitForSeconds(0.05f);

        _rend.color = new Color(1, 1, 1, 1);
    }

    IEnumerator StopDeley()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
