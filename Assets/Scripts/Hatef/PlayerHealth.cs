using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public float healthRemaining;
    public float healthMax;
    public Slider s;

    void Start()
    {
        healthRemaining = healthMax;
        s.value = HealthCalc();
    }

    void Update()
    {
         s.value = HealthCalc();
        if (healthRemaining <= 0){
            SceneManager.LoadScene("SnowBiome");
            //Destroy(gameObject);
            
        }
    }
    float HealthCalc(){
        return healthRemaining/healthMax;

    }
    void OnCollisionEnter(Collision coll)
    {
        Debug.Log(coll.gameObject.tag);
        string name = coll.gameObject.tag;
        switch(name){
            case "Enemy":
                healthRemaining-= 5f;
                break;
            //case "dog":
            //    healthRemaining-= 10f;
            //    break;
            //case "polarBear":
            //    healthRemaining-= 20f;
            //    break;
            //case "chicken":
            //    healthRemaining-= 5f;
            //    break;
            //case "lion":
            //    healthRemaining-= 20f;
            //    break; 
            //case "penguin":
            //    healthRemaining-= 10f;
            //    break;
            //case "SnowGlobe":
            //    healthRemaining-= 10f;
            //    break;
            //case "snowman":
            //    healthRemaining-= 25f;
            //    break;
            default:
                break;
        }  

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
