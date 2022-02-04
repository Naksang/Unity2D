using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonSetting : MonoBehaviour
{
    public Canvas _baseCanvas;
    public Canvas _characterCanvas;
    public Canvas _OptionCanvas;

    public Image[] _coin;
    public Image[] _gem;
    Color _uColor;

    public GameObject[] _characterPanel;
    int _panelNumber;

    string _noticeName = null;
    int _noticeCount = 0;
    int _noticePrice = 0;

    private void Start()
    {
        _uColor = new Color(_coin[0].color.r, _coin[0].color.g, _coin[0].color.b, _coin[0].color.a);
    }

    public void OnClick_GameStart()
    {
        if (SingletonManager.instance.WingNum <= 0) return;

        SingletonManager.instance.WingNum -= 1;
        SceneManager.LoadScene("GameScene");
    }

    public void OnClick_Character()
    {
        GameObject.Find("BaseCanvas").transform.Find("Character").transform.GetChild(SingletonManager.instance.CharacterNumber).gameObject.SetActive(false);
        _characterCanvas.gameObject.SetActive(true);
        _baseCanvas.gameObject.SetActive(false);
        _panelNumber = SingletonManager.instance.CharacterNumber;
        _characterPanel[_panelNumber].SetActive(true);
    }

    public void OnClick_Item()
    {

    }

    public void OnClick_Dragon()
    {

    }

    public void OnClick_Store()
    {
        GameObject.Find("StoreCanvas").transform.Find("ItemStore").gameObject.SetActive(true);
    }

    public void OnClick_Option()
    {
        _OptionCanvas.gameObject.SetActive(true);
    }

    //캐릭터 캔버스 작동
    public void OnClick_C_CloseCharacter()
    {
        _characterCanvas.gameObject.SetActive(false);
        _baseCanvas.gameObject.SetActive(true);
        GameObject.Find("BaseCanvas").transform.Find("Character").transform.GetChild(SingletonManager.instance.CharacterNumber).gameObject.SetActive(true);
    }

    public void OnClick_C_BackCharacter()
    {
        _characterPanel[_panelNumber].SetActive(false);
        if (_panelNumber < 0) _panelNumber = 3;
        else _panelNumber--;
        _characterPanel[_panelNumber].SetActive(true);
    }

    public void OnClick_C_NextCharacter()
    {
        _characterPanel[_panelNumber].SetActive(false);
        if (_panelNumber >= 3) _panelNumber = 0;
        else _panelNumber++;
        _characterPanel[_panelNumber].SetActive(true);
    }

    public void OnClick_C_Selectharacter()
    {
        SingletonManager.instance.CharacterNumber = _panelNumber;
    }

    //옵션 캔버스 작동
    public void OnClick_O_BackTitle()
    {
        _OptionCanvas.gameObject.SetActive(false);
        SceneManager.LoadScene("StartScene");
    }

    public void OnClick_O_CloseOption()
    {
        _OptionCanvas.gameObject.SetActive(false);
    }

    //상단바
    public void OnClick_U_BuyCoin()
    {
        GameObject.Find("StoreCanvas").transform.Find("CoinStore").gameObject.SetActive(true);
        Text Coin = GameObject.Find("StoreCanvas").transform.Find("CoinStore").transform.Find("Text").GetChild(0).transform.Find("Text").GetComponent<Text>();
        Coin.text = SingletonManager.instance.CoinNum + "";
    }
    public void OnClick_U_CloseCoin()
    {
        for (int i = 0; i < _coin.Length; i++)
        {
            _coin[i].color = _uColor;
        }

        GameObject.Find("StoreCanvas").transform.Find("CoinStore").gameObject.SetActive(false);
    }

    public void Onclick_U_Coin()
    {
        for (int i = 0; i < _coin.Length; i++)
        {
            _coin[i].color = _uColor;
        }

        _noticeName = "코인";

        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "Coin_10":
                {
                    _coin[0].color = Color.white;
                    _noticeCount = 10;
                    _noticePrice = 10;
                    break;
                }
            case "Coin_50":
                {
                    _coin[1].color = Color.white;
                    _noticeCount = 50;
                    _noticePrice = 50;
                    break;
                }
            case "Coin_100":
                {
                    _coin[2].color = Color.white;
                    _noticeCount = 100;
                    _noticePrice = 100;
                    break;
                }
            case "Coin_500":
                {
                    _coin[3].color = Color.white;
                    _noticeCount = 500;
                    _noticePrice = 500;
                    break;
                }
            case "Coin_1000":
                {
                    _coin[4].color = Color.white;
                    _noticeCount = 1000;
                    _noticePrice = 1000;
                    break;
                }
            case "Coin_5000":
                {
                    _coin[5].color = Color.white;
                    _noticeCount = 5000;
                    _noticePrice = 5000;
                    break;
                }
        }
    }

    public void OnClick_U_BuyGem()
    {
        GameObject.Find("StoreCanvas").transform.Find("GemStore").gameObject.SetActive(true);
        Text Gem = GameObject.Find("StoreCanvas").transform.Find("GemStore").transform.Find("Text").GetChild(0).transform.Find("Text").GetComponent<Text>();
        Gem.text = SingletonManager.instance.GemNum + "";
    }
    public void OnClick_U_CloseGem()
    {
        for (int i = 0; i < _gem.Length; i++)
        {
            _gem[i].color = _uColor;
        }

        GameObject.Find("StoreCanvas").transform.Find("GemStore").gameObject.SetActive(false);
    }

    public void Onclick_U_Gem()
    {
        for (int i = 0; i < _gem.Length; i++)
        {
            _gem[i].color = _uColor;
        }

        _noticeName = "수정";

        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "Gem_10":
                {
                    _gem[0].color = Color.white;
                    _noticeCount = 10;
                    _noticePrice = 1000;
                }
                break;
            case "Gem_35":
                {
                    _gem[1].color = Color.white;
                    _noticeCount = 35;
                    _noticePrice = 2990;
                }
                break;
            case "Gem_60":
                {
                    _gem[2].color = Color.white;
                    _noticeCount = 60;
                    _noticePrice = 4990;
                }
                break;
            case "Gem_130":
                {
                    _gem[3].color = Color.white;
                    _noticeCount = 130;
                    _noticePrice = 9990;
                }
                break;
            case "Gem_420":
                {
                    _gem[4].color = Color.white;
                    _noticeCount = 420;
                    _noticePrice = 29990;
                }
                break;
            case "Gem_750":
                {
                    _gem[5].color = Color.white;
                    _noticeCount = 750;
                    _noticePrice = 49990;
                }
                break;
        }
    }
   
    public void OnClick_U_BuyWing()
    {

    }
    public void OnClick_U_Select()
    {
        if(_noticeName != null)
        {
            GameObject.Find("StoreCanvas").transform.Find("Notice").gameObject.SetActive(true);
            Text ItemName = GameObject.Find("StoreCanvas").transform.Find("Notice").transform.Find("ItemName").GetComponent<Text>();
            ItemName.text = _noticeName + " " + _noticeCount + "\n" + _noticePrice;
        }
    }
    public void OnClick_U_NoNotice()
    {
        _noticeName = null;
        _noticeCount = 0;
        _noticePrice = 0;
        GameObject.Find("StoreCanvas").transform.Find("Notice").gameObject.SetActive(false);
    }
    public void OnClick_U_YesNotice()
    {
        if(_noticeName == "코인")
        {
            if (_noticePrice > SingletonManager.instance.GemNum) return; //골드가 부족합니다

            GameObject.Find("ItemManager").GetComponent<ItemManager>().Coin += _noticeCount;
            GameObject.Find("ItemManager").GetComponent<ItemManager>().Gem -= _noticePrice;

            for (int i = 0; i < _coin.Length; i++)
            {
                _coin[i].color = _uColor;
            }
        }
        else if(_noticeName == "수정")
        {
            //본인인증이 필요합니다

            /*
            * 해당 아이템을 더 이상 소지할 수 없습니다.
            * 무기 업그레이드 레벨 최고치를 달성하였습니다
            * 더 이상 무기를 강화할 수 없습니다.
            */
        }

        _noticeName = null;
        _noticeCount = 0;
        _noticePrice = 0;
        GameObject.Find("StoreCanvas").transform.Find("Notice").gameObject.SetActive(false);
    }
}
