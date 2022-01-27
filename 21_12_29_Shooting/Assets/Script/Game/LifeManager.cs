using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    SpriteRenderer[] _lifespr = null;

    int _initLife;
    bool _blink = false;

    void Start()
    {
        _initLife = 2;
        _lifespr = this.GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    public void Damaged()
    {
        if (_initLife < 0) return;

        if (_blink == false)
        {
            _blink = true;
            StartCoroutine(Blink());
        }
    }

    IEnumerator Blink()
    {
        _lifespr[_initLife].enabled = false;
        yield return new WaitForSeconds(0.3f);
        _lifespr[_initLife].enabled = true;
        yield return new WaitForSeconds(0.3f);
        _lifespr[_initLife].enabled = false;
        yield return new WaitForSeconds(0.3f);
        _lifespr[_initLife].enabled = true;
        yield return new WaitForSeconds(0.3f);
        _lifespr[_initLife].enabled = false;

        _initLife--;

        _blink = false;
    }
}
