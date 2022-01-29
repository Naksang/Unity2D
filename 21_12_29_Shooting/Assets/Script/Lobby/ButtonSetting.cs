using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSetting : MonoBehaviour
{
    public Canvas _baseCanvas;
    public Canvas _characterCanvas;

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
        
    }

    //캐릭터 캔버스 작동
    public void OnClick_C_BackBaseCanvas()
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
        SingletonManager.instance.CharacterNumber = PlayerPrefs.GetInt("CharacterNum", _panelNumber);
    }
}
