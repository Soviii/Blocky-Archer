using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    GameObject[] targetArray = new GameObject[3];
    bool[] isHit = new bool[9];
    [SerializeField] int count = 0;
    [SerializeField] float speed = 20.0f;


    void Start()
    {
        targetArray = GameObject.FindGameObjectsWithTag("Target");
        for (int i = 0; i < 9; i++)
        {
            isHit[i] = false;
        }
    }

    void Update()
    {
        if (count == 9)
        {
            Debug.Log("Gate Activated!");

            if (transform.position.y < 10)
                transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        }

        CheckForHits();
    }

    void CheckForHits()
    {
        for (int i = 0;i < 9; i++)
        {
            if (targetArray[i].GetComponent<target>().targetHit == true && isHit[i] == false)
            {
                isHit[i] = true;
                count++;
            }

        }
    }
}
