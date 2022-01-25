using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObj : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyOb());
    }

    IEnumerator DestroyOb()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
}
