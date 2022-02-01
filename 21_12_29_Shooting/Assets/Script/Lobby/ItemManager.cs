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

    public Text _coinText;
    int _coin;

    public Text _wingTimeText;
    float _creatTime = 300.0f;
    float _wingTime;

    void Start()
    {
        _wing = 5;
        _gem = 10000;
        _coin = 1000;

        SingletonManager.instance.WingNum = _wing;
        SingletonManager.instance.GemNum = _gem;
        SingletonManager.instance.CoinNum = _coin;
        _wingTime = _creatTime;

        _gemText.text = _gem + "";
        _coinText.text = _coin + "";

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
