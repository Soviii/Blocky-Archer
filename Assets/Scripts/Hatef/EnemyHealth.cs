using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public GameObject PlayerGO;
    public float healthRemaining;
    public float healthMax;
    public Slider s;
    public Poof p;
    [SerializeField] public AudioClip death;


    void Start()
    {
       // PlayerGO = GameObject.FindGameObjectWithTag("Player");
        healthRemaining = healthMax;
        s.value = HealthCalc();
        p = GameObject.Find("Smoke").GetComponent<Poof>();
    
    }

    void Update()
    {
        

        s.transform.LookAt(PlayerGO.transform);
        s.value = HealthCalc();
        if (healthRemaining <= 0){
            //if (gameObject.tag == "snowman"){ 
            //    SceneManager.LoadScene("SnowBiome");
            //
            
            Destroy(gameObject);
            p.transform.position = gameObject.transform.position;
            p.poof();           
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
            healthRemaining-= 20f;
         }

    }

    //public void ahh(Poof go)
    //{
    //    if (t == true)
    //    {
    //        Destroy(gameObject);
    //        go.transform.position = gameObject.transform.position;
    //        go.poof();
    //        t = false;
    //    }
    //}
}
