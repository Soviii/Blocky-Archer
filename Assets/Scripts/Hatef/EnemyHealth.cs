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

    void Start()
    {
       // PlayerGO = GameObject.FindGameObjectWithTag("Player");

        healthRemaining = healthMax;
        s.value = HealthCalc();
    }

    void Update()
    {
        s.transform.LookAt(PlayerGO.transform);
        s.value = HealthCalc();
        if (healthRemaining <= 0){
            if (gameObject.tag == "snowman"){
                SceneManager.LoadScene("SnowBiome");
            }
            Destroy(gameObject);
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
}
