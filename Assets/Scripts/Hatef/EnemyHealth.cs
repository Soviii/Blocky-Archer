using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public GameObject PlayerGO;
    public float healthRemaining;
    public float healthMax;
    public Slider s;
    // Start is called before the first frame update
    void Start()
    {
        PlayerGO = GameObject.FindGameObjectWithTag("Player");
        healthRemaining = healthMax;
        s.value = HealthCalc();
    }

    // Update is called once per frame
    void Update()
    {
        s.transform.LookAt(PlayerGO.transform);
        s.value = HealthCalc();
        if (healthRemaining <= 0){
            Destroy(gameObject);
        }
    }

    float HealthCalc(){
        return healthRemaining/healthMax;

    }
    
    void OnCollisionEnter(Collision coll)
    {
         if (coll.gameObject.tag == "Player"){
            Debug.Log("player");
         }
        if (coll.gameObject.tag == "arrow"){
            healthRemaining-= 20f;
         }

    }
}
