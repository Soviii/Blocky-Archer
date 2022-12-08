using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleDrop : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clip;
    Rigidbody rb;
    bool canDamage;
    public Trigger trScript;
    public GameObject trGo;
    private BoxCollider bc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        audio = GetComponent<AudioSource>();
        //bc.enabled = false;
        canDamage = true;
        trGo = GameObject.FindGameObjectWithTag("Trigger");
        trScript = trGo.GetComponent<Trigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(trScript.isTriggered){
            if(!audio.isPlaying){
                audio.PlayOneShot(clip);
            }
            rb.useGravity = true;
            bc.isTrigger = false;
            //bc.enabled = true;
        }
    }

    void OnCollisionEnter(Collision coll)
    {   
        //Debug.Log("COOOOLLLISSSSION");
        //Debug.Log(coll.gameObject.tag);
        //useGravity = false;
        if (coll.gameObject.tag == "arrow"){
            Debug.Log("arrows_icicle");
            rb.useGravity = true;
        }

        /*if (coll.gameObject.tag == "Enemy" && canDamage){
            //Debug.Log("Animal");
            Destroy(coll.gameObject);
        }*/

        if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "IceSheet" || coll.gameObject.tag == "ramp"){
            //GetComponent<BoxCollider>().enabled = false;
            //canDamage = false;
            
            //Debug.Log("Hit the ground");
            Destroy(this.gameObject);
            //Destroy(this.gameObject);
            //GetComponent<BoxCollider>().isTrigger = true;
        }

    }
    void OnTriggerEnter(Collider coll){
        if (coll.gameObject.tag == "arrow"){
            audio.PlayOneShot(clip);
            Debug.Log("arrows_icicle");
            rb.useGravity = true;
            bc.isTrigger = false;
        }
    }
}
