using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StoneWallContact : MonoBehaviour
{
    Explode exp;
    GameObject stoneWall;
    private GameObject Player;
    public bool collapsed = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        stoneWall = GameObject.Find("StoneWall");
        exp = stoneWall.GetComponent<Explode>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision coll){

        if (coll.gameObject.tag == "arrow" && !collapsed){
            exp.explode = true;
            GameObject.FindGameObjectWithTag("BossEntranceVCam").GetComponent<CinemachineVirtualCamera>().Priority = 20;
            collapsed = true;
            Invoke("PrioritizePlayerCamera", 3f);
        }
    }

    void PrioritizePlayerCamera(){
        GameObject.FindGameObjectWithTag("BossEntranceVCam").GetComponent<CinemachineVirtualCamera>().Priority = 1;
    }
}
