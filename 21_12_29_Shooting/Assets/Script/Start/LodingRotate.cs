using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LodingRotate : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(new Vector3(0, 0, -200.0f * Time.deltaTime));
    }
}
