using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleDrop : MonoBehaviour
{
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
        bc.enabled = false;
        canDamage = true;
        trGo = GameObject.FindGameObjectWithTag("Trigger");
        trScript = trGo.GetComponent<Trigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(trScript.isTriggered){
            rb.useGravity = true;
            bc.enabled = true;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        Debug.Log(coll.gameObject.tag);
        //useGravity = false;
        if (coll.gameObject.tag == "arrow"){
            Debug.Log("arrows_icicle");
            rb.useGravity = true;
        }

        if (coll.gameObject.tag == "Enemy" && canDamage){
            Debug.Log("Animal");
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "ground"){
            //GetComponent<BoxCollider>().enabled = false;
            canDamage = false;
            //Debug.Log("Animal");
            //Destroy(this.gameObject);
            //GetComponent<BoxCollider>().isTrigger = true;
        }
        

    }
}
