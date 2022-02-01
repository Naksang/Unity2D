using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSetting : MonoBehaviour
{
    public Canvas _baseCanvas;
    public Canvas _characterCanvas;
    public Canvas _OptionCanvas;

    public GameObject[] _characterPanel;
    int _panelNumber;

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
    }

    public void OnClick_U_CloseCoin()
    {
        GameObject.Find("StoreCanvas").transform.Find("CoinStore").gameObject.SetActive(false);
    }

    public void OnClick_U_BuyGem()
    {
        GameObject.Find("StoreCanvas").transform.Find("GemStore").gameObject.SetActive(true);
    }

    public void OnClick_U_CloseGem()
    {
        GameObject.Find("StoreCanvas").transform.Find("GemStore").gameObject.SetActive(false);
    }

    public void OnClick_U_BuyWing()
    {

    }

}
