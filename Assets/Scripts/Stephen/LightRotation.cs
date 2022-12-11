using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    [SerializeField] float rotation = 20.0f;
    public Key k;
    public UnlockLH ul;
    public Boat b;
    public GameObject testBoat;

    private void Start()
    {
        k = GameObject.FindGameObjectWithTag("Key").GetComponent<Key>();
        ul = GameObject.FindGameObjectWithTag("LHColl").GetComponent<UnlockLH>();
        b = GameObject.FindGameObjectWithTag("Boat").GetComponent<Boat>();
        testBoat = GameObject.Find("TestBoat").GetComponent<GameObject>();

    }


    void Update()
    {
        if (k.hasKey == true && ul.unlock == true)
        {
            rotate(); 
            b.boatMove();
        }
    }

    public void rotate()
    {
       
            transform.Rotate(0f, rotation * Time.deltaTime, 0f, Space.Self);
            Debug.Log("Let There Be Light!");
    }
}
