using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public Text _touchPls;

    public Slider _lodingGage;
    float _maxGage = 100.0f;
    float _initGage;

    bool _touch = false;

    public Image _loding;
    float _deleyTime = 10.0f;


    void Update()
    {
        if(!_touch)
        {
            GageCharging();
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                DeleyNextScene();
            }

        }
    }

    void GageCharging()
    {
        if (_initGage >= _maxGage)
        {
            _lodingGage.gameObject.SetActive(false);
            _touchPls.gameObject.SetActive(true);
            _touch = true;

        }
        else
        {
            _initGage += Time.deltaTime * 100;
            _lodingGage.value = _initGage / _maxGage;
        }
    }  
    
    void DeleyNextScene()
    {

    }
}
