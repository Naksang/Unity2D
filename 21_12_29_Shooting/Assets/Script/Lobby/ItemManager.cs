using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Text _wingText;
    int _wing;

    public Text _gemText;
    int _gem;
    public int Gem
    {
        get { return _gem; }
        set
        {
            _gem = value;
            SingletonManager.instance.GemNum = _gem;
            _gemText.text = _gem + "";
        }
    }

    public Text _coinText;
    int _coin;
    public int Coin
    {
        get { return _coin; }
        set
        {
            _coin = value;
            SingletonManager.instance.CoinNum = _coin;
            _coinText.text = _coin + "";
        }
    }


    public Text _wingTimeText;
    float _creatTime = 300.0f;
    float _wingTime;

    void Start()
    {
        _wing = PlayerPrefs.GetInt("Wing", 5);
        _gem = PlayerPrefs.GetInt("Gem", 10000);
        _coin = PlayerPrefs.GetInt("Coin", 1000);

        SingletonManager.instance.GemNum = _gem;
        SingletonManager.instance.CoinNum = _coin;
        SingletonManager.instance.WingNum = _wing;

        _gemText.text = _gem + "";
        _coinText.text = _coin + "";

        _wingTime = _creatTime;

        GameObject.Find("BaseCanvas").transform.Find("Character").transform.GetChild(SingletonManager.instance.CharacterNumber).gameObject.SetActive(true);
    }

    void Update()
    {
        _wingText.text = _wing + "";
        _wingTimeText.text = (int)_wingTime / 60 + ":" + (int)_wingTime % 60;

        _wingTime -= Time.deltaTime;
        
        if(_wingTime <= 0)
        {
            _wing++;
            _wingTime = _creatTime;
        }
    }
}
