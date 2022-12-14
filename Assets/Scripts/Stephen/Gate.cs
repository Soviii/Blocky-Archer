using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] public bool moveUp = false;


    public void openGate()
    {
        if (transform.position.y < 15)

        {
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);

        }
    }
}
