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

    float scaleX;
    float scaleY;
    float scaleZ;
    //public GameObject go;
    public float speed = 750f;
    public float contanctDistance = 75f;
    public bool attack;
    public bool firstTime;
    private DateTime start;
    private DateTime finish;
    int ret;

    public bool isDead;
    public bool stop;

    public GameObject rightArm; 
    public GameObject leftArm;
    public GameObject nose;
    public GameObject rightEye;
    public GameObject leftEye;
    
    Drop dropNose;
    Drop dropLeftArm;
    Drop dropRightArm;
    Drop dropRightEye;
    Drop dropLeftEye;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        attack = false;
        firstTime = true;
        stop = true;
        ret = -1;
        player = GameObject.FindGameObjectWithTag("Player");

        /*nose = GameObject.Find("NS");
        rightArm = GameObject.Find("RA");
        leftArm = GameObject.Find("LA");
        rightEye = GameObject.Find("RE");
        leftEye = GameObject.Find("LE");

        dropNose = nose.GetComponent<Drop>();
        dropRightArm = rightArm.GetComponent<Drop>();
        dropLeftArm = leftArm.GetComponent<Drop>();
        dropRightEye = rightEye.GetComponent<Drop>();
        dropLeftEye = leftEye.GetComponent<Drop>();*/

        distance = Vector3.Distance(player.transform.position, transform.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        /*if(isDead && stop){
            dropNose.drop = true;
            dropRightArm.drop = true;
            dropLeftArm.drop = true;
            dropRightArm.drop = true;
            dropRightEye.drop = true;
            dropLeftEye.drop = true;
            //isDead = false;
            stop = false;
        }*/


        if(distance < activationdistance){
            attack = true;
        }
        distance = Vector3.Distance(player.transform.position, transform.transform.position);
        multiplier = distance/contanctDistance;

        if (attack && !isDead){

            if(firstTime){
               Timer(); 
            }
            ret=DateTime.Compare(DateTime.Now, finish);

            if (0 <= ret || firstTime){
                GameObject go = Instantiate(projectile, transform.position, transform.rotation);
                go.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,multiplier*speed,0));
                Timer();
                
                firstTime = false;
            }
        }
    }

    private void Timer(){
            start = DateTime.Now;
            finish = start.AddSeconds(1);
    }  
}
