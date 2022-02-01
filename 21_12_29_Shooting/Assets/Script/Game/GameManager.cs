using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject _player;

    //시간이 갈수록 증가
    public Text _meterText;
    float _meter = 0;
    public float Meter
    {
        get { return _meter; }
        set 
        {
            _meter = value;
        }
    }

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

    private void Awake()
    {
        GameObject Character = Instantiate(Resources.Load<GameObject>("Prefab/Character_" + SingletonManager.instance.CharacterNumber));
        Character.transform.parent = _player.transform;
        Character.transform.position = _player.transform.position;
    }

    void Update()
    {
        _meter += Time.deltaTime * 100;
        //_meter += float.Parse(Time.deltaTime.ToString("N2"));
        _meterText.text = _meter.ToString("F0") + "m";

        SingletonManager.instance.CurrMeter = _meter;
        SingletonManager.instance.CurrScore = _score;
        SingletonManager.instance.CurrCoin = _coin;
    }
}
