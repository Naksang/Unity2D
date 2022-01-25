using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    int _initfire;

    void Start()
    {
        _initfire = 0;
    }

    public void PowerUpFire()
    {
        this.transform.GetChild(_initfire).GetComponent<FireSprite>().OnSprite();
        _initfire++;
    }

    public void PowerDownFire()
    {
        this.transform.GetChild(_initfire).GetComponent<FireSprite>().OffSprite();
        _initfire--;
    }
}
