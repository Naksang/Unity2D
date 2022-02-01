using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1Move : MonoBehaviour
{
    public GameObject _coinSource;

    public GameObject _fly_right;
    public GameObject _fly_left;
    bool fold_r = false;
    bool fold_l = false;
    float _rightRot;
    float _leftRot;
    float _flySpeed;

    SpriteRenderer _rend;

    Slider _hpBar;
    float _maxHp;
    float _hp;
    public float HP
    {
        get { return _hp; }
        set { _hp = value; }
    }

    float _speed = 5.0f;

    Vector3 dir;

    void Start()
    {
        _fly_right = this.transform.GetChild(0).transform.GetChild(0).gameObject;
        _fly_left = this.transform.GetChild(0).transform.GetChild(1).gameObject;

        _leftRot = _fly_left.transform.rotation.eulerAngles.z;
        _rightRot = _fly_right.transform.rotation.eulerAngles.z;

        _rend = this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        _hpBar = this.transform.GetChild(1).transform.GetChild(0).GetComponent<Slider>();

        dir = Vector3.down;
        _maxHp = 3;
        _hp = _maxHp;
    }

    void Update()
    {
        if (_hp <= 0)
        {
            GameObject Coin = Instantiate(_coinSource);
            Coin.transform.position = this.transform.position;

            Destroy(this.gameObject);

            GameObject.Find("GameManager").GetComponent<GameManager>().Score += 100;
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
            _hpBar.gameObject.SetActive(true);
            _hp -= collision.gameObject.GetComponent<FireMove>().Damege;
            _hpBar.value = _hp / _maxHp;
            Destroy(collision.gameObject);
            StartCoroutine(ChangeColor());
        }
    }

    void FlyAnimation()
    {
        if (!fold_l)
        {
            if (_fly_left.transform.rotation.eulerAngles.z > 50.0f) fold_l = true;
            else
            {
                Mathf.Abs(_leftRot += 5 * Time.deltaTime);
                //_fly_right.transform.Rotate(0, 0, _leftRot);
                _fly_right.transform.eulerAngles += new Vector3(0, 0, _leftRot);
            }
        }
        else
        {
            if (_fly_left.transform.rotation.eulerAngles.z <= 0) fold_l = false;
            else
            {
                _leftRot -= 5 * Time.deltaTime;
                //_fly_right.transform.Rotate(0, 0, -_leftRot);
                _fly_right.transform.eulerAngles -= new Vector3(0, 0, _leftRot);
            }
            
        }
       
        if(!fold_r)
        {
            if (_fly_right.transform.rotation.eulerAngles.z < -50.0f) fold_r = true;
            else
            {
                _rightRot -= 5 * Time.deltaTime;
                //_fly_right.transform.Rotate(0, 0, -_rightRot);
                _fly_right.transform.eulerAngles -= new Vector3(0, 0, _rightRot);
            }

        }
        else
        {
            if (_fly_right.transform.rotation.eulerAngles.z >= 0) fold_r = false;
            else
            {
                Mathf.Abs(_rightRot += 5 * Time.deltaTime);
                //_fly_right.transform.Rotate(0, 0, _rightRot);
                _fly_right.transform.eulerAngles += new Vector3(0, 0, _rightRot);
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
