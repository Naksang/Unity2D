using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("Canvas").transform.Find("Character").transform.GetChild(SingletonManager.instance.CharacterNumber).gameObject.SetActive(true);
    }

    void Update()
    {
        
    }

    public void OnClick_Store()
    {

    }

    public void OnClick_ReStart()
    {
        if (SingletonManager.instance.WingNum <= 0) return;

        SingletonManager.instance.WingNum -= 1;
        SceneManager.LoadScene("GameScene");
    }
}
