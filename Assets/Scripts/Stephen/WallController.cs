using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    GameObject[] targetArray = new GameObject[3];
    bool[] isHit = new bool[3];
    [SerializeField] int count = 0;


    void Start()
    {
        targetArray = GameObject.FindGameObjectsWithTag("Target");
        for (int i = 0; i < 3; i++)
        {
            isHit[i] = false;
        }
    }

    void Update()
    {
        if (count == 3)
        {
            Debug.Log("disabled");
            this.gameObject.SetActive(false);
        }
        CheckForHits();
    }

    void CheckForHits()
    {
        for (int i = 0;i < 3; i++)
        {
            if (targetArray[i].GetComponent<target>().targetHit == true && isHit[i] == false)
            {
                isHit[i] = true;
                count++;
            }

        }
    }
}
