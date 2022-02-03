using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PatternManager : MonoBehaviour
{
    Boss1Move _boss1Move = null;

    _RotFire _rotfire = null;
    _CicleFire _ciclefire = null;
    _CrossFire _crossfire = null;
    _SpinFire _spinfire = null;
    _BloommingFire _bloommingfire = null;

    void Start()
    {
        _boss1Move = this.GetComponent<Boss1Move>();

        _rotfire = this.GetComponent<_RotFire>();
        _ciclefire = this.GetComponent<_CicleFire>();
        _crossfire = this.GetComponent<_CrossFire>();
        _spinfire = this.GetComponent<_SpinFire>();
        _bloommingfire = this.GetComponent<_BloommingFire>();

        _ciclefire.enabled = true;
    }

    void Update()
    {
        if(_boss1Move.Delay)
        {
            _ciclefire.enabled = false;
            _bloommingfire.enabled = true;
        }
        else
        {
            _ciclefire.enabled = true;
            _bloommingfire.enabled = false;
        }
    }
}
