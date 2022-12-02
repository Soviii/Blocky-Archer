using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    [SerializeField] float rotation = 20.0f;
  
    void Update()
    {
        transform.Rotate(0f, rotation * Time.deltaTime, 0f, Space.Self);

        //rotate();
    }

    //void rotate(bool activate)
    //{

    //    transform.Rotate(0f, rotation * Time.deltaTime, 0f, Space.Self);

    //}
}
