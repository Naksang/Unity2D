using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //시간이 갈수록 증가
    public Text _meterText;
    float _meter = 0;

    //몬스터 제거 시 증가
    public Text _scoreText;
    float _score = 0;
    public float Score
    {
        get { return _score; }
        set
        {
            _score = value;
            _scoreText.text = "" + _score;
        }
    }

    //동전을 모으면 증가
    public Text _coinText;
    int _coin = 0;
    public int Coin
    {
        get { return _coin; }
        set
        {
            _coin = value;
            _coinText.text = "" + _coin;
        }
    }

    public Slider _powerGage;
    float _maxPower = 3;
    float _power;
    public float Power
    {
        get { return _power; }
        set
        {
            _power = value;
            _powerGage.value = _power / _maxPower;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        _meter += Time.deltaTime;
        _meterText.text = _meter + "m";
    }
}
