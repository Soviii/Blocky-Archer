using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Explode : MonoBehaviour
{
    int count;
    int numChilds;  
    int ret;
    //GameObject[] toBeDestroyed;
    private DateTime start;
    private DateTime finish;
    // Start is called before the first frame update
    //public GameObject go;
    //Rigidbody rb;
    public AudioSource audio;
    public AudioClip clip;
    public bool explode;
    public bool e;
    public bool done;
    //bool firstTime;

    void Start()
    {
        
        numChilds = transform.childCount;
        //toBeDestroyed = new GameObject[(numChilds/2)+1];
        done = false;
        Debug.Log("Number Of Childs At first");
        Debug.Log(numChilds);
        count = 0;
        ret = -1;
        audio = GetComponent<AudioSource>();
        explode = false;
        e = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(explode){
            SetKinematic();
            audio.PlayOneShot(clip);
            Timer();
            Debug.Log("now");
            Debug.Log(DateTime.Now);
            Debug.Log("finish");
            Debug.Log(finish);
            explode = false;
            e = true;
        }
        if(e){
            Debug.Log("**********************RET**********");
           
            ret=DateTime.Compare(DateTime.Now, finish);
            Debug.Log(ret);
            Debug.Log("**************************************");
            Debug.Log("**************************************");
        }
        if (0 <= ret && !done){
            e = false;
            done = true;
            DestoryRocks();
            //e = false;
            //Debug.Log("**************************************");
            //Debug.Log("**************************************");
            //Debug.Log("**************************************");
            //Debug.Log(numChilds);
            //Debug.Log("**************************************");
            //Debug.Log("**************************************");
            //Debug.Log("**************************************");
        }

    }

    /*void OnCollisionEnter(Collision coll){

        if (coll.gameObject.tag = "arrow"){
            explode = true;
        }
    }*/

    void SetKinematic(){
        foreach (Transform child in transform){
            //count++;
            GameObject go = child.transform.gameObject;
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.isKinematic=false;

        }

    }
    private void Timer(){
        start = DateTime.Now;
        finish = start.AddSeconds(5);

    }
    private void DestoryRocks(){
        foreach (Transform child in transform){
            count++;
            GameObject go = child.transform.gameObject;
            //Debug.Log();
            Destroy(go);
        }
    }
}
