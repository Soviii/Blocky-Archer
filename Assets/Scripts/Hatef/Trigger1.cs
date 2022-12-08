using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1 : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clip;
    public bool isTriggered;
    public GameObject icicles;
    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if(isTriggered){
            audio.PlayOneShot(clip);
            foreach (Transform child in icicles.transform){
                child.GetComponent<Rigidbody>().useGravity = true;
                child.GetComponent<BoxCollider>().isTrigger = false;
            }
            isTriggered = false;
            //Destroy(gameObject);
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider coll){
        if(coll.gameObject.tag == "Player"){
            isTriggered = true;
        }
    }
}
