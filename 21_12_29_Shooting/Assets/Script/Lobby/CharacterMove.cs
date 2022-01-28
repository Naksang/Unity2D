using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    RectTransform _charaRect;

    float _upPos;
    float _downPos;

    void Start()
    {
        _charaRect = this.GetComponent<RectTransform>();
        _upPos = _charaRect.position.y;
        _downPos = _upPos - 30.0f;

        StartCoroutine(MoveDown());
    }

    IEnumerator MoveUp()
    {
        while(_charaRect.position.y < _upPos)
        {
            _charaRect.Translate(Vector3.up * 20 * Time.deltaTime);
            yield return null;
        }
        StartCoroutine(MoveDown());
    }

    IEnumerator MoveDown()
    {
        while (_charaRect.position.y > _downPos)
        {
            _charaRect.Translate(Vector3.down * 20 * Time.deltaTime);
            yield return null;
        }
        StartCoroutine(MoveUp());
    }
}
