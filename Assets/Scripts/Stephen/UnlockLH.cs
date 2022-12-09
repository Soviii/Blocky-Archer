using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLH : MonoBehaviour
{

    public bool unlock = false;
    public Key k;

    void Start()
    {
        k = GameObject.FindGameObjectWithTag("Key").GetComponent<Key>();
    }

 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && k.hasKey == true)
        {
            unlock = true;

        }
    }

}
