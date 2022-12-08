using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

    Rigidbody rb;
    public bool drop; 

    // Start is called before the first frame update
    void Start()
    {
        drop = false;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (drop){
            rb.useGravity=true;
            rb.isKinematic = false;
            //drop = false;
        }
    }
    void OnCollisionEnter(Collision coll){

        if(coll.gameObject.tag == "Ground"){
            Debug.Log("&&&&&&&&&&&&&&&&&&&&&&&&&&&###################");
            Debug.Log(gameObject.name);
                    //Debug.Log(coll.gameObject.tag);
            rb.useGravity = false;
            rb.isKinematic = true;
        }
        //Debug.Log("&&&&&&&&&&&&&&&&&&&&&&&&&&&###################");
        //Debug.Log(coll.gameObject.tag);
    }
}
