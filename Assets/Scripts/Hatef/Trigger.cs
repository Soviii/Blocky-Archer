using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isTriggered;
    public GameObject iceSheet1;
    public GameObject iceSheet2;
    MeshCollider mc1;
    MeshCollider mc2;

    public AudioSource audio;
    public AudioClip clip;
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
        if(coll.gameObject.tag == "Player"){
            //Debug.Log("QQQQQQQQQQQQQQQ");
            isTriggered = true;
            mc1.isTrigger = false;
            mc2.isTrigger = false;
            
        }
    }
}
