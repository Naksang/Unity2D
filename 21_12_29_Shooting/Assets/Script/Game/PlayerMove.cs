using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    GameObject _fly_right;
    GameObject _fly_left;
    bool fold = false;

    float createTiem = 0.02f;
    float initTime;

    Transform _playertrans;
    float _speed = 10.0f;
    bool _blink = false;

    private void Start()
    {
        _fly_right = this.transform.GetChild(1).transform.GetChild(0).gameObject;
        _fly_left = this.transform.GetChild(1).transform.GetChild(1).gameObject;
        _playertrans = this.transform.GetChild(1);
    }

    void Update()
    {
        if (initTime > createTiem)
        {
            FlyAnimation();
            initTime = 0;
        }

        if (_blink) return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = Vector3.right * h + Vector3.up * v;

        this.transform.Translate(dir * _speed * Time.deltaTime);

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;

        initTime += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            if (_blink == false)
            {
                _blink = true;
                StartCoroutine(PlayerBlink());
            }

            LifeManager lm = GameObject.Find("LifeZone").GetComponent<LifeManager>();
            lm.Damaged();
        }    
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Coin += 100;
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("PowerUp"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Power++;
            Destroy(collision.gameObject);
        }
    }

    void FlyAnimation()
    {
        if(!fold)
        {
            if (_fly_left.transform.localScale.x < 0.5) fold = true;
            else
            {
                _fly_left.transform.localScale -= new Vector3(0.1f, 0, 0);
            }
            if (_fly_right.transform.localScale.x < 0.5) fold = true;
            else
            {
                _fly_right.transform.localScale -= new Vector3(0.1f, 0, 0);
            }
        }
        else
        {
            if (_fly_left.transform.localScale.x >= 1) fold = false;
            else
            {
                _fly_left.transform.localScale += new Vector3(0.1f, 0, 0);
            }
            if (_fly_right.transform.localScale.x >= 1) fold = false;
            else
            {
                _fly_right.transform.localScale += new Vector3(0.1f, 0, 0);
            }
        }
    }

    IEnumerator PlayerBlink()
    {
        _playertrans.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        _playertrans.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _playertrans.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        _playertrans.gameObject.SetActive(true);

        _blink = false;
    }
}
