using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public Light light;
    bool increase;
    bool decrease;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();   
        increase = false;
        decrease = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){
        if (decrease){
            if(light.intensity > 2.5){
                //increase =true;
                light.intensity -= 0.05f;
            }
            else{
                decrease = false;
                increase = true;
            }
        }

        if (increase){
            if(light.intensity < 10){
                //increase =true;
                light.intensity += 0.05f;
            }
            else{
                decrease = true;
                increase = false;
            }
        }

    }
}
