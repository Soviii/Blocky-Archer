using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleDrop : MonoBehaviour
{
    Rigidbody rb;
    bool canDamage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        
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
