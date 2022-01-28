using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSetting : MonoBehaviour
{
    public Canvas _baseCanvas;
    public Canvas _characterCanvas;

    public void OnClick_GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnClick_Character()
    {
        _characterCanvas.gameObject.SetActive(true);
        _baseCanvas.gameObject.SetActive(false);
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


    public void OnClick_C_BackBaseCanvas()
    {
        _characterCanvas.gameObject.SetActive(false);
        _baseCanvas.gameObject.SetActive(true);
    }
}
