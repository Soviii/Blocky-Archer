using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingWall : MonoBehaviour
{
    GameObject[] targetArray = new GameObject[3];
    bool[] isHit = new bool[3];
    [SerializeField] int count = 0;
    [SerializeField] float speed = 20.0f;


    void Start()
    {
        targetArray = GameObject.FindGameObjectsWithTag("TrainTarg");
        for (int i = 0; i < 3; i++)
        {
            isHit[i] = false;
        }
    }

    void Update()
    {
        if (count == 3)
        {
            Debug.Log("Gate Activated!");

            if (transform.position.y < 10)
                transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        }

        CheckForHits();
    }

    void CheckForHits()
    {
        for (int i = 0; i < 3; i++)
        {
            if (targetArray[i].GetComponent<TrainTarg>().targetHit == true && isHit[i] == false)
            {
                isHit[i] = true;
                count++;
            }

        }
    }
}

