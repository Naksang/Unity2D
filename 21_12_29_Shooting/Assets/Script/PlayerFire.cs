using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject _fireSource;

    public Transform _firePos;
    
    [SerializeField]
    float _createTime = 0.1f;
    float _initTime;

    void Start()
    {
        _initTime = _createTime;
        //_firePos = GetComponentInChildren<Transform>().Find("firePos");
    }

    private void Update()
    {
        _initTime += Time.deltaTime;

        if(Input.GetKey(KeyCode.Space))
        {
            if (_initTime > _createTime)
            {
                GameObject fire = Instantiate(_fireSource);
                fire.transform.position = _firePos.position;

                _initTime = 0;
            }
        }
    }
}
