using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMove : MonoBehaviour
{
    float _speed = 2.0f;

    Vector3 dir;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        dir = (player.transform.position - this.transform.position);
        dir.Normalize();
    }

    void Update()
    {
        this.transform.position += dir * _speed * Time.deltaTime;
        this.transform.Rotate(new Vector3(0, 0, 100 * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerFire"))
        {
            GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            gm.Score += 100;

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
