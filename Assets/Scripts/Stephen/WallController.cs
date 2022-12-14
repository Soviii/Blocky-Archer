using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WallController : MonoBehaviour
{
    GameObject[] targetArray = new GameObject[3];
    bool[] isHit = new bool[9];
    [SerializeField] int count = 0;
    [SerializeField] float speed = 20.0f;
    [SerializeField] public AudioClip rockWall;
    private bool alreadyLifted = false;


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
        if (count == 9 && !alreadyLifted)
        {
            Debug.Log("Gate Activated!");
            GameObject.FindGameObjectWithTag("StoneWallVCam").GetComponent<CinemachineVirtualCamera>().Priority = 40;

            if (transform.position.y < 10)
            {
                transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
                AudioSource.PlayClipAtPoint(rockWall, transform.position);
            }
            
            Invoke("SwitchBackToPlayerCam", 2f);
        }

        CheckForHits();
    }

    void SwitchBackToPlayerCam(){
        GameObject.FindGameObjectWithTag("StoneWallVCam").GetComponent<CinemachineVirtualCamera>().Priority = 1;
        alreadyLifted = true;
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
