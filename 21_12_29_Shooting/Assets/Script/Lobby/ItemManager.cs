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

    public Text _wingTimeText;
    float _creatTime = 300.0f;
    float _wingTime;

    void Start()
    {
        _wing = 5;
        _gem = 10000;

        SingletonManager.instance.WingNum = _wing;
        SingletonManager.instance.GemNum = _gem;
        _wingTime = _creatTime;

        _gemText.text = _gem + "";

        SingletonManager.instance.CharacterNumber = PlayerPrefs.GetInt("CharacterNum", 3);
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
