using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WingManager : MonoBehaviour
{
    public Text _wingText;
    int _wing;
    public int Wing { get { return _wing; } set { _wing = value; } }

    public Text _time;
    float _createTime = 300.0f;
    float _initTime;
    


    void Start()
    {
        _wing = 10;
        _initTime = _createTime;
    }

    void Update()
    {
        _wingText.text = _wing + "";
        _time.text = (int)_initTime / 60 + ":" + (int)_initTime % 60;

        _initTime -= Time.deltaTime;

        if(_initTime <= 0)
        {
            _wing++;

        _initTime = _createTime;
        }
    }
}
