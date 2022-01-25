using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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
            _scoreText.text = "Score : " + _score;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
