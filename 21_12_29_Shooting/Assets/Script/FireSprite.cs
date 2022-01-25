using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSprite : MonoBehaviour
{
    SpriteRenderer _firespr = null;
    Animator _fireAni = null;

    void Start()
    {
        _firespr = this.GetComponent<SpriteRenderer>();
        _fireAni = this.GetComponent<Animator>();
    }

    public void OnSprite()
    {
        _fireAni.SetBool("fire_on", true);
        _firespr.enabled = true;
    }

    public void FireSpriteOn()
    {
        _fireAni.SetBool("fire_off", true);
    }

    public void OffSprite()
    {
        _fireAni.SetBool("fire_on", false);
    }

    public void FireSpriteOff()
    {
        _fireAni.SetBool("fire_off", false);
        _firespr.enabled = false;
    }
}
