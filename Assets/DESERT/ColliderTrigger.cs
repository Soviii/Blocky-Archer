using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderTrigger : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip honk;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerItems>().obtainedKey == true)
        {
            other.gameObject.SetActive(false);
            audioSource.PlayOneShot(honk);
            Invoke("LoadNextScene", 1.5f);
            print("Reached the end");
        }
    }

    private void LoadNextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
