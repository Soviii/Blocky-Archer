using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //public GameObject AimCanvas;
    //public GameObject thirdPersonCanvas;
    public GameObject PlayerHealthbar;

    //public GameObject playerPackageGO;
    public void ShowScreen(){
        //Destroy(PlayerHealthbar);
        //Destroy(thirdPersonCanvas);
        //Destroy(AimCanvas);
        //playerPackageGO.SetActive(false);
        //Destroy(GameObject.Find("PlayerHealthbar"))
        if(PlayerHealthbar != null){
            PlayerHealthbar.SetActive(false);
        }
        //GameObject.Find("PlayerHealthbar").SetActive(false);
        //GameObject.Find("3rdPersonCanvas").SetActive(false);
        //GameObject.Find("AimCanvas").SetActive(false);
        gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartLevel(){
        Debug.Log("RESTART");
        string sceneName =  SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        //SceneManager.LoadScene("SnowBiome");
    }
}