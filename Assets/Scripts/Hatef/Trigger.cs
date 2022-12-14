using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Trigger : MonoBehaviour
{
    public bool isTriggered;
    public GameObject iceSheet1;
    public GameObject iceSheet2;
    MeshCollider mc1;
    MeshCollider mc2;

    public AudioSource audio;
    public AudioClip clip;
    public bool collapsed = false;
    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;
        
        iceSheet1 = GameObject.Find("IceSheet1");
        iceSheet2 = GameObject.Find("IceSheet2");

        mc1 = iceSheet1.GetComponent<MeshCollider>();
        mc2 = iceSheet2.GetComponent<MeshCollider>();

        audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTriggered){
            audio.PlayOneShot(clip);
            GetComponent<BoxCollider>().enabled = false;
            isTriggered = false;
        }
    }
    void OnTriggerEnter(Collider coll){
        if(coll.gameObject.tag == "Player" && !collapsed){
            //Debug.Log("QQQQQQQQQQQQQQQ");
            isTriggered = true;
            mc1.isTrigger = false;
            mc2.isTrigger = false;
            GameObject.FindGameObjectWithTag("StalVCam").GetComponent<CinemachineVirtualCamera>().Priority = 20;
            collapsed = true;
            Invoke("PrioritizePlayerCamera", 4f);
        }
    }

    void PrioritizePlayerCamera(){
        GameObject.FindGameObjectWithTag("StalVCam").GetComponent<CinemachineVirtualCamera>().Priority = 1;
    }
}
