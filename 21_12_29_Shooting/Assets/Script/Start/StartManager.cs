using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public Image _kakao;
    public Image _nextfloor;
    public Image _nextfloorT;

    bool _start = false;

    public Text _touchPls;

    public Slider _lodingGage;
    float _maxGage = 100.0f;
    float _initGage;

    bool _touch = false;

    public Transform _loding;
    float _deleyTime = 2.0f;
    bool _lodingRot = true;

    private void Start()
    {
        GameObject.Find("Canvas").transform.Find("Character").GetChild(SingletonManager.instance.CharacterNumber).gameObject.SetActive(true);

        StartCoroutine(KaKaoGame());
    }

    void Update()
    {
        if (!_start) return;
        if(!_touch)
        {
            GageCharging();
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(DeleyNextScene());
            }
        }
    }

    //로딩 게이지
    void GageCharging()
    {
        if (_initGage >= _maxGage)
        {
            _lodingGage.gameObject.SetActive(false);
            _touchPls.gameObject.SetActive(true);
            _touch = true;

            StartCoroutine(FadeOutText());
        }
        else
        { 
            _initGage += Time.deltaTime * 100;
            _lodingGage.value = _initGage / _maxGage;
        }
    }

    IEnumerator KaKaoGame()
    {
        yield return new WaitForSeconds(_deleyTime);
        _kakao.gameObject.SetActive(false);
        _nextfloor.gameObject.SetActive(true);
        StartCoroutine(NextFloar());
    }

    IEnumerator NextFloar()
    {
        _nextfloorT.color = new Color(_nextfloorT.color.r, _nextfloorT.color.g, _nextfloorT.color.b, 0);
        while (_nextfloorT.color.a < 1.0f) 
        {
            _nextfloorT.color = new Color(_nextfloorT.color.r, _nextfloorT.color.g, _nextfloorT.color.b, _nextfloorT.color.a + (Time.deltaTime / 1.5f));
            yield return null;
        }
        yield return new WaitForSeconds(_deleyTime);
        _nextfloor.gameObject.SetActive(false);
        _start = true;
    }
    
    //화면을 터치해주세요 깜빡이는 효과
    IEnumerator FadeOutText()
    {
        _touchPls.color = new Color(_touchPls.color.r, _touchPls.color.g, _touchPls.color.b, 1);
        while(_touchPls.color.a > 0)
        {
            _touchPls.color = new Color(_touchPls.color.r, _touchPls.color.g, _touchPls.color.b, _touchPls.color.a - (Time.deltaTime / 1.5f));
            yield return null;
        }
        StartCoroutine(FadeInText());
    }

    IEnumerator FadeInText()
    {
        _touchPls.color = new Color(_touchPls.color.r, _touchPls.color.g, _touchPls.color.b, 0);
        while (_touchPls.color.a < 1.0f)
        {
            _touchPls.color = new Color(_touchPls.color.r, _touchPls.color.g, _touchPls.color.b, _touchPls.color.a + (Time.deltaTime / 1.5f));
            yield return null;
        }
        StartCoroutine(FadeOutText());
    }

    //다음화면 넘어갈 딜레이
    IEnumerator DeleyNextScene()
    {
        _touchPls.gameObject.SetActive(false);
        _loding.gameObject.SetActive(true);

        yield return new WaitForSeconds(_deleyTime);
        _lodingRot = false;
        SceneManager.LoadScene("LobbyScene");
    }
}
