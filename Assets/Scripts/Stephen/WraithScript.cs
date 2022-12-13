using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class WraithScript : MonoBehaviour
{
    //public Vector3 scaleChange;
    public float damage;
    private DateTime start;
    private DateTime finish;
    int ret;
    public AudioSource audio;
    public AudioClip clip;
    Animator anim;
    Transform playerTransform;
    public Transform t1;
    Transform t2;
    Transform t3;
    Transform t4;
    public GameObject PlayerGO;
    public float attackSpeed;
    public float rotSpeed = 3f;
    public float activationdistance;
    public float patrolDistance;
    [SerializeField] float distance;
    //[SerializeField] float patrolDistance;
    public bool attack;
    public bool inRange;
    public bool patrol;
    public bool forward;
    private NavMeshAgent navMeshAgent;
    public Vector3 pos;
    public Vector3 pos1;
    public float posX;
    public float posY;
    public float posZ;
    //Vector3[] positions;
    public bool isBoss;
    public bool playSound;
    private bool firstTime;
    public bool isDead;
    public bool hasAnimation;
    public bool stopTimer;


    int runAnimation;
    int idleAnimation;
    Vector3 previousPos;
    bool isRunning = false;
    // Start is called before the first frame update
    void Awake(){
        //scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
        playSound = true;
        isDead = false;
        //firstTime = true;
        audio = GetComponent<AudioSource>();
        forward = true;
        inRange = false;
        navMeshAgent=GetComponent<NavMeshAgent>();

        PlayerGO = GameObject.FindGameObjectWithTag("Player");

        playerTransform = PlayerGO.transform;
        t1 = GetComponent<Transform>();
        pos1.x = t1.transform.position.x;
        pos1.z = t1.transform.position.z;
        pos1.y = t1.transform.position.y;
        //pos = new Vector3(t1.transform.position.x + 10f,
         //t1.transform.position.y, t1.transform.position.z);
        //posX = t1.transform.position.x + 20f;
        posX = t1.transform.position.x + patrolDistance;
        //t2 = t1;
        //t2.position = pos;
        // Debug.Log(t1.transform.position.x);
        Debug.Log(posX);
        pos.x = posX;
        pos.y = t1.transform.position.y;
        pos.z = t1.transform.position.z;
        //t2.position = pos;

        idleAnimation = Animator.StringToHash("Idle");
        runAnimation = Animator.StringToHash("Run");
        
    }
    
    void Start()
    {
        stopTimer = false;
        ret = -1;
        anim = GetComponent<Animator>();

        // if (anim  != null){
        //     //hasAnimation = true;
        //     anim.SetInteger("Walk", 1);
        // }
        // /*else{
        //     hasAnimation = false;
        // }*/

        distance = Vector3.Distance(PlayerGO.transform.position, transform.transform.position);
        previousPos = transform.position;
        //Debug.Log(distance);
        
        //attack = true;
        //patrol = false;
        anim.CrossFade(runAnimation, 0.15f);

    }
    private void Timer(){
            start = DateTime.Now;
            finish = start.AddSeconds(2);
    }  
    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.tag !="Ground"){
            //Debug.Log("GGGGOOIINGGG BAAAAAACK");
            forward = !forward;
        }
        EnemyHealth eh = GetComponent<EnemyHealth>();

        if (eh.healthRemaining == 0){
            anim.CrossFade(idleAnimation, 0.15f);
        }
        
     }
    // Update is called once per frame
    void Update()
    {
        // if(anim != null && isDead){
        //     anim.SetInteger("Walk", 0);
        // }

        distance = Vector3.Distance(PlayerGO.transform.position, transform.transform.position);

        if(isDead && gameObject.tag != "snowman"){
            if(!stopTimer){
                Timer();
                stopTimer = true;
            }

            ret=DateTime.Compare(DateTime.Now, finish);
            if (0 <= ret && !audio.isPlaying ){
                Invoke("DestroyWraith", 2f);
            }
            
            audio.volume = 0;
            transform.localRotation = Quaternion.Euler(0, 0, 90);
            /*if(transform.localRotation.z < 90f){
                Debug.Log("Dying");
                float z = transform.localRotation.z;
                z += rotSpeed * Time.deltaTime;
                //transform.localRotation = Quaternion.Euler(0, 0, z);
            }*/
            
        }
        else{
            audio.volume = 1-distance/activationdistance;
        }
        //audio.volume = 1-distance/activationdistance;
        /*if(isBoss){

            Debug.Log("distance:");
            Debug.Log(distance);        
        }*/
        if (distance < activationdistance && !isDead){
            //firstTime = false;
            if (audio != null && !audio.isPlaying && playSound){
                audio.PlayOneShot(clip);
                //playSound = false;
            }
            inRange = true;
            //playSound = false;
            //audio.PlayOneShot(clip);
        }



        /*else{
            inRange = false;
        }*/
        if (inRange && !isDead){
            //Debug.Log("DFDFFDFDFDFDf");
            navMeshAgent.speed = attackSpeed;
            navMeshAgent.SetDestination(playerTransform.position);
            /*transform.rotation = Quaternion.Slerp(transform.rotation
            , Quaternion.LookRotation(playerTransform.position-transform.position), rotSpeed*Time.deltaTime);

            transform.position += transform.forward*attackSpeed*Time.deltaTime;*/
        }
        else if(!isDead && gameObject.tag != "snowman"){
            if (forward){
                //Debug.Log("forward");
                if (Vector3.Distance(transform.position, pos) > 2f){
                    //Debug.Log("Destination");
                    navMeshAgent.SetDestination(pos);
                }
                else{
                    forward = false;
                }
            }
            else{
                //Debug.Log("back");
                //Debug.Log(Vector3.Distance(transform.position, t2.transform.position));
                if (Vector3.Distance(transform.position, pos1) > 2f){
                    navMeshAgent.SetDestination(pos1);
                }
                else{
                    //Debug.Log("for");
                    forward = true;
                }
            }

        }
        
        // if (previousPos == transform.position && isRunning){
        //     anim.CrossFade(idleAnimation, 0.15f);
        //     isRunning = false;
        // } else {
        //     anim.CrossFade(runAnimation, 0.15f);
        //     isRunning = true;
        // }

    }

    // private void FixedUpdate() {
    //     if((int)Time.timeSinceLevelLoad % 2 == 0){
    //         if(isRunning && previousPos == transform.position){
    //             anim.CrossFade(idleAnimation, 0.15f);
    //             isRunning = false;
    //         } else if (!isRunning && previousPos != transform.position){
    //             anim.CrossFade(runAnimation, 0.15f);
    //             isRunning = true;
    //         }
    //     }

    //     previousPos = transform.position;
    // }

    void DestroyWraith(){
        Destroy(this.gameObject);
    }
}