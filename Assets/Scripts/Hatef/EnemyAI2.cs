using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI2 : MonoBehaviour
{
    Animator anim;
    Transform playerTransform;
    public Transform t1;
    Transform t2;
    Transform t3;
    Transform t4;
    GameObject PlayerGO;
    public float attackSpeed;
    public float rotSpeed = 3f;
    public float activationdistance;
    [SerializeField] float distance;
    [SerializeField] float patrolDistance;
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
    Vector3[] positions;
    // Start is called before the first frame update
    void Awake(){
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
        posX = t1.transform.position.x + 20f;
        //t2 = t1;
        //t2.position = pos;
        Debug.Log(t1.transform.position.x);
        Debug.Log(posX);
        pos.x = posX;
        pos.y = t1.transform.position.y;
        pos.z = t1.transform.position.z;
        //t2.position = pos;

        
    }
    
    void Start()
    {
        anim = GetComponent<Animator>();
        //anim.SetInteger("Walk", 1);
        //playerTransform = PlayerGO.transform;
        distance = Vector3.Distance(PlayerGO.transform.position, transform.transform.position);
        //Debug.Log(distance);
        
        //attack = true;
        //patrol = false;
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(PlayerGO.transform.position, transform.transform.position);
        if (distance < activationdistance ){
            inRange = true;
        }

        /*else{
            inRange = false;
        }*/
        if (inRange){
            navMeshAgent.speed = attackSpeed;
            navMeshAgent.SetDestination(playerTransform.position);
            /*transform.rotation = Quaternion.Slerp(transform.rotation
            , Quaternion.LookRotation(playerTransform.position-transform.position), rotSpeed*Time.deltaTime);

            transform.position += transform.forward*attackSpeed*Time.deltaTime;*/
        }
        else{
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

    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player"){
            Debug.Log("player");
        }
        if (coll.gameObject.tag == "arrow"){
            Debug.Log("arrows");
        }

    }

    /*void OnCollisionExit(Collision coll)
    {
         if (coll.gameObject.tag == "Player"){
            attack = true;
         }
    }*/



}
