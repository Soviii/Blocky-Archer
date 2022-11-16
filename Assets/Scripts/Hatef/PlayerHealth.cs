using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Put this in whenever you want to load a scene


public class PlayerHealth : MonoBehaviour
{
    public float healthRemaining;
    public float healthMax;
    public Slider s;
    // Start is called before the first frame update
    void Start()
    {
        healthRemaining = healthMax;
        s.value = HealthCalc();
    }

    // Update is called once per frame
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

        if (coll.gameObject.tag == "Enemy"){
            healthRemaining-= 20f;
        }

    }
}
