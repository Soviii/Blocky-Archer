using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FinalBoss : MonoBehaviour
{
    public float distance;
    public float activationdistance;
    public float multiplier;
    public GameObject projectile;
    public GameObject player;
    //public GameObject go;
    public float speed = 750f;
    public float contanctDistance = 75f;
    public bool attack;
    public bool firstTime;
    private DateTime start;
    private DateTime finish;
    int ret;
    // Start is called before the first frame update
    void Start()
    {
        attack = false;
        firstTime = true;
        ret = -1;
        player = GameObject.FindGameObjectWithTag("Player");
        distance = Vector3.Distance(player.transform.position, transform.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        if(distance < activationdistance){
            attack = true;
        }
        distance = Vector3.Distance(player.transform.position, transform.transform.position);
        multiplier = distance/contanctDistance;

        //transform.LookAt(player.transform);
        /*if (attack){
            //Input.GetKey ("x")
            GameObject go = Instantiate(projectile, transform.position, transform.rotation);
            go.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,multiplier*speed,0));
        }*/

        if (attack){
            
            //Input.GetKey ("x")
            //GameObject go = Instantiate(projectile, transform.position, transform.rotation);
            //go.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,multiplier*speed,0));
            //Timer();
            //Debug.Log("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            //Debug.Log(DateTime.Now);
            //Debug.Log(finish);
            //int ret=DateTime.Compare(DateTime.Now, finish);
            //Debug.Log(ret);
            //Debug.Log("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            if(firstTime){
               Timer(); 
            }
            ret=DateTime.Compare(DateTime.Now, finish);

            if (0 <= ret || firstTime){
                Debug.Log("TIMETIME");
                GameObject go = Instantiate(projectile, transform.position, transform.rotation);
                go.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,multiplier*speed,0));
                Timer();
                //ret=DateTime.Compare(DateTime.Now, finish);
                firstTime = false;
            }
        }
    }

    void FixedUpdate(){
        
        /*if (attack){

            //Input.GetKey ("x")
            //GameObject go = Instantiate(projectile, transform.position, transform.rotation);
            //go.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,multiplier*speed,0));
            //Timer();
            //Debug.Log("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            //Debug.Log(DateTime.Now);
            //Debug.Log(finish);
            //int ret=DateTime.Compare(DateTime.Now, finish);
            //Debug.Log(ret);
            //Debug.Log("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            

            if (0 <= ret || firstTime){
                Debug.Log("TIMETIME");
                GameObject go = Instantiate(projectile, transform.position, transform.rotation);
                go.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,multiplier*speed,0));
                Timer();
                ret=DateTime.Compare(DateTime.Now, finish);
                firstTime = false;
            }
        }*/

    }
    private void Timer(){
            start = DateTime.Now;
            finish = start.AddSeconds(2);
            /*Debug.Log("Start");
            Debug.Log(start);
            Debug.Log("finish");
            Debug.Log(finish);*/


    }  
}
