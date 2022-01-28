using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemManager : MonoBehaviour
{
    public Text _gemText;
    int _gem;
    public int Gem { get { return _gem; } set { _gem = value; } }

    void Start()
    {
        _gem = 10000;
    }

    void Update()
    {
        _gemText.text = _gem + "";
    }
}
