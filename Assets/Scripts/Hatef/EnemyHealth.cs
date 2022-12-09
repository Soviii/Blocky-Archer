using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip hurt;
    public AudioClip die;
    public GameObject head;
    public GameObject body;
    Vector3 pos;
    public GameObject PlayerGO;
    public float healthRemaining;
    public float healthMax;
    public Slider s;
    public bool isDeadFB;
    GameObject finalBossGo1;
    FinalBoss finalBossScript1;

    GameObject finalBossGo3;
    FinalBoss finalBossScript3;
    public EnemyAI2 enemyAiScript;

    GameObject finalBossGo2;
    FinalBoss finalBossScript2;
    public Vector3 scaleChange;
    public bool stop;
    public GameObject go;
    public GameOver gameOverScript;
    //public bool playSound;

    GameObject snowMan;
    
    // Start is called before the first frame update
    void Start()
    {
        //playSound = true;
        
        stop = false;
        scaleChange = new Vector3(-0.001f, -0.001f, -0.001f);
        audio = GetComponent<AudioSource>();
        finalBossGo1 =GameObject.Find("Projectile1");
        finalBossGo2 =GameObject.Find("Projectile2");
        finalBossGo3 =GameObject.Find("Projectile3");
        
        finalBossScript1=finalBossGo1.GetComponent<FinalBoss>();
        finalBossScript2=finalBossGo2.GetComponent<FinalBoss>();
        finalBossScript3=finalBossGo3.GetComponent<FinalBoss>();
        //PlayerGO = GameObject.FindGameObjectWithTag("Player");
        //snowMan = GameObject.FindGameObjectWithTag("snowman");
        //enemyAiScript = snowMan.GetComponent<EnemyAI2>();
        enemyAiScript = GetComponent<EnemyAI2>();
        /*if(enemyAiScript == null){
            Debug.Log("NULL");
        }*/
        healthRemaining = healthMax;
        s.value = HealthCalc();
    }

    // Update is called once per frame
    void Update()
    {
        s.transform.LookAt(PlayerGO.transform);
        s.value = HealthCalc();
        if (healthRemaining <= 0){
            enemyAiScript.isDead = true;
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            s.gameObject.SetActive(false);
            if (gameObject.tag == "snowman"){
                //Debug.Log("BOSS DEAD");
                if(!audio.isPlaying){
                    audio.PlayOneShot(die);
                }
                gameOverScript = go.GetComponent<GameOver>();
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                finalBossScript1.isDead = true;
                finalBossScript2.isDead = true;
                finalBossScript3.isDead = true;

                //enemyAiScript.isDead = true;

                //pos = transform.position;
                //float posY = pos.y;
                float scaleX=transform.localScale.x;
                float scaleY=transform.localScale.y;
                float scaleZ=transform.localScale.z;

                if(scaleX > 0.01f || scaleY > 0.01f || scaleZ > 0.01f){
                    transform.localScale += 10f*scaleChange;
                }
                else{
                    gameOverScript.ShowScreen();
                    Destroy(gameObject);
                }
                //float scaleXB=body.transform.localScale.x;
                //float scaleYB=body.transform.localScale.y;
                //float scaleZB=body.transform.localScale.z;
                /*if(scaleXH > 0.01f && scaleYH > 0.01f && scaleZH > 0.01f
                    && scaleXB > 0.01f && scaleYB > 0.01f && scaleZB > 0.01f){
                    //float posY = transform.position.y;
                    body.transform.localScale += scaleChange;
                    head.transform.localScale += scaleChange;
                    foreach (Transform child in transform){
                        GameObject go = child.transform.gameObject;
                        if(go.name == "Head" || go.name == "Body"){
                            go.transform.localScale += scaleChange;
                        }
                        //MeshCollider mc = go.GetComponent<MeshCollider>();
                        //mc.isTrigger = true;
                    }
                    //pos.y = transform.position.x;
                    //pos.y-= 2f*Time.deltaTime;
                    //Debug.Log(pos.y);
                    //pos.y = posY;
                    //transform.position = pos;
                    //transform.localScale += scaleChange;
                }*/
                //SceneManager.LoadScene("SnowBiome");
            }
            else{
                //Destroy(gameObject);
            }
            
        }
    }

    float HealthCalc(){
        return healthRemaining/healthMax;

    }
    
    void OnCollisionEnter(Collision coll)
    {
        /*if (coll.gameObject.tag == "Player"){
            Debug.Log("playerplayer");
        }*/
        if (coll.gameObject.tag == "arrow"){
            /*if (!audio.isPlaying){
                audio.PlayOneShot(hurt);
                //playSound = false;
            }
            else{
                enemyAiScript.playSound = false;
            }*/
            audio.PlayOneShot(hurt);
            //inRange = true;
            //playSound = false;
            healthRemaining-= 20f;
        }

    }
}
