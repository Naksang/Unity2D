using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text _meterText;
    float _meter = 0;

    public Text _scoreText;
    float _score = 0;
    public float Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            _scoreText.text = "" + _score;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        _meter += Time.deltaTime;
        _meterText.text = (int)_meter + "m";
    }
}
