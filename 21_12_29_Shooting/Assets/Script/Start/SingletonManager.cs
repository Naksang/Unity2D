using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    public static SingletonManager instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        CharacterNumber = 3;
    }

    public int CharacterNumber { get; set; }

    public int WingNum { get; set; }
    public int GemNum { get; set; }
    public int CoinNum { get; set; }

    public float CurrMeter { get; set; }
    public float CurrScore { get; set; }
    public int CurrCoin { get; set; }
    public int BestTotal { get; set; }

}
