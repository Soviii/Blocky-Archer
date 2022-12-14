using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockShatter : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;
    public GameObject p7;
    public GameObject p8;
    Rigidbody rb1;
    Rigidbody rb2;
    Rigidbody rb3;
    Rigidbody rb4;
    Rigidbody rb5;
    Rigidbody rb6;
    Rigidbody rb7;
    Rigidbody rb8;


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        p1 = GameObject.Find("P1");
        p2 = GameObject.Find("P2");
        p3 = GameObject.Find("P3");
        p4 = GameObject.Find("P4");
        p5 = GameObject.Find("P5");
        p6 = GameObject.Find("P6");
        p7 = GameObject.Find("P7");
        p8 = GameObject.Find("P8");

        rb1 =p1.GetComponent<Rigidbody>();
        rb2 =p2.GetComponent<Rigidbody>();
        rb3 =p3.GetComponent<Rigidbody>();
        rb4 =p4.GetComponent<Rigidbody>();
        rb5 =p5.GetComponent<Rigidbody>();
        rb6 =p6.GetComponent<Rigidbody>();
        rb7 =p7.GetComponent<Rigidbody>();
        rb8 =p8.GetComponent<Rigidbody>();



    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.tag == "arrow"){
            rb1.isKinematic=false; 
            rb2.isKinematic=false; 
            rb3.isKinematic=false; 
            rb4.isKinematic=false; 
            rb5.isKinematic=false; 
            rb6.isKinematic=false; 
            rb7.isKinematic=false; 
            rb8.isKinematic=false; 
        }
        
        //Debug.Log(coll.gameObject.tag);
    }
}
