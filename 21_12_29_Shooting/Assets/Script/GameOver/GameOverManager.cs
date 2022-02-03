using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text _meterText;
    public Text _scoreText;
    public Text _totalText;
    public Text _bestText;
    public Text _coinText;

    int _bestTotal; 
    float _textAni;
    int _textNum = 0;

    void Start()
    {
        _bestTotal = PlayerPrefs.GetInt("BestTotal", 0);
        GameObject.Find("Canvas").transform.Find("Character").transform.GetChild(SingletonManager.instance.CharacterNumber).gameObject.SetActive(true);
        _textAni = 0;
    }

    void Update()
    {
        

        switch (_textNum)
        {
            case 0:
                {
                    if (_textAni > SingletonManager.instance.CurrMeter)
                    {
                        _meterText.text = SingletonManager.instance.CurrMeter.ToString("F0") + "m";
                        _textNum = 1;
                        _textAni = 0;

                        StartCoroutine(DelayTime());
                    }
                    else
                    {
                        _textAni += Time.deltaTime * SingletonManager.instance.CurrMeter;
                        _meterText.text = _textAni + "m";
                    }
                }
                break;
            case 1:
                {
                    if (_textAni > SingletonManager.instance.CurrScore)
                    {
                        _scoreText.text = SingletonManager.instance.CurrScore + "";
                        _textNum = 2;
                        _textAni = 0;

                        StartCoroutine(DelayTime());
                    }
                    else
                    {
                        _textAni += Time.deltaTime * SingletonManager.instance.CurrScore;
                        _scoreText.text = _textAni + "";
                    }
                }
                break;
            case 2:
                {
                    if (_textAni > SingletonManager.instance.CurrMeter + SingletonManager.instance.CurrScore)
                    {
                        int _total = (int)(SingletonManager.instance.CurrMeter + SingletonManager.instance.CurrScore);
                        _totalText.text = _total + "";
                        _textNum = 3;
                        _textAni = 0;

                        if (_total > _bestTotal)
                            _bestTotal = _total;
                        PlayerPrefs.SetInt("BestTotal", _bestTotal);
                        SingletonManager.instance.BestTotal = PlayerPrefs.GetInt("BestTotal");
                        _bestText.text = _bestTotal + "";

                        StartCoroutine(DelayTime());
                    }
                    else
                    {
                        _textAni += Time.deltaTime * (SingletonManager.instance.CurrMeter + SingletonManager.instance.CurrScore);
                        _totalText.text = _textAni + "";
                    }
                }
                break;
            case 3:
                {
                    _coinText.text = SingletonManager.instance.CurrCoin + "";
                }
                break;
        }
    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(0.5f);
    }

    public void OnClick_Store()
    {

    }

    public void OnClick_ReStart()
    {
        if (SingletonManager.instance.WingNum <= 0) return;

        SingletonManager.instance.WingNum -= 1;
        SceneManager.LoadScene("GameScene");
    }

    public void OnClick_Lobby()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
