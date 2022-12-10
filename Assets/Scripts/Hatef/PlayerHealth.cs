using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Put this in whenever you want to load a scene


public class PlayerHealth : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip hurt;
    public float healthRemaining;
    public float healthMax;
    public Slider s;
    //public GameObject go;
    //public GameOver gameOverScript;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        //gameOverScript = go.GetComponent<GameOver>();
        
        healthRemaining = healthMax;
        if(s != null){
            s.value =HealthCalc();
        }
        //s.value = HealthCalc();

    }

    // Update is called once per frame
    void Update()
    {
         s.value = HealthCalc();
        if (healthRemaining <= 0){
            //gameOverScript.ShowScreen();
            //SceneManager.LoadScene("SnowBiome");
            string sceneName =  SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);
            //Destroy(gameObject);
            
        }
    }
    float HealthCalc(){
        return healthRemaining/healthMax;

    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag != "icicle" && coll.gameObject.tag !="SnowGlobe" && coll.gameObject.tag !="Untagged" ){
            if(audio != null){
                audio.PlayOneShot(hurt);
            }
            //audio.PlayOneShot(hurt);
            if(coll.gameObject.GetComponent<EnemyAI2>()!= null){
                healthRemaining-=coll.gameObject.GetComponent<EnemyAI2>().damage;
            }
            //healthRemaining-=coll.gameObject.GetComponent<EnemyAI2>().damage;
        }
        else{
            if (coll.gameObject.tag == "SnowGlobe"){
                audio.PlayOneShot(hurt);
                healthRemaining-= 20f;
            }
            if(coll.gameObject.tag == "icicle"){
                audio.PlayOneShot(hurt);
                healthRemaining -=60;
            }
        }
        //Debug.Log(coll.gameObject.tag);
        /*string name = coll.gameObject.tag;
        switch(name){
            case "cat":
                healthRemaining-= 5f;
                audio.PlayOneShot(hurt);
                break;
            case "dog":
                healthRemaining-= 10f;
                audio.PlayOneShot(hurt);
                break;
            case "polarBear":
                healthRemaining-= 20f;
                audio.PlayOneShot(hurt);
                break;
            case "chicken":
                healthRemaining-= 5f;
                audio.PlayOneShot(hurt);
                break;
            case "lion":
                healthRemaining-= 20f;
                break; 
            case "penguin":
                healthRemaining-= 10f;
                audio.PlayOneShot(hurt);
                break;
            case "SnowGlobe":
                healthRemaining-= 10f;
                audio.PlayOneShot(hurt);
                break;
            case "snowman":
                healthRemaining-= 25f;
                audio.PlayOneShot(hurt);
                break;*/
            /*case "IceSheet":
                healthRemaining -= 50f;
                audio.PlayOneShot(hurt);
                break;*/
            /*case "icicle":
                healthRemaining = -=50f;
                audio.PlayOneShot(hurt);
                break;
            default:
                break;
        }*/  

        /*if (coll.gameObject.tag == "Enemy"){
            healthRemaining-= 20f;
        }*/
        /*if (coll.gameObject.tag == "SnowGlobe"){
            healthRemaining-= 20f;
        }*/

    }
    void OnTriggerEnter(Collider coll){
        if (coll.gameObject.tag == "water"){
            healthRemaining = 0;
        }
    }
}
