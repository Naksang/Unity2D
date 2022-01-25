using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float _speed = 10.0f;
    Transform _playertrans;

    bool _blink = false;

    private void Start()
    {
        _playertrans = this.transform.GetChild(0);
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = Vector3.right * h + Vector3.up * v;

        this.transform.Translate(dir * _speed * Time.deltaTime);

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyFire"))
        {
            LifeManager lm = GameObject.Find("LifeZone").GetComponent<LifeManager>();
            lm.Damaged();

            if (_blink == false)
            {
                _blink = true; 
                StartCoroutine(PlayerBlink());
            }
        }    
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin"))
        {
            GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            gm.Score += 100;
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("PowerUp"))
        {
            FireManager fm = GameObject.Find("FireZone").GetComponent<FireManager>();
            fm.PowerUpFire();
            Destroy(collision.gameObject);
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
