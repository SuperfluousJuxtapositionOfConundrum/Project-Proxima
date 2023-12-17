using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{   
    [SerializeField] float loadDelay = 2f;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] AudioClip successSFX;

    AudioSource audioSource;
    Movement movement;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        movement = GetComponent<Movement>();
        movement.enabled = true;
    }

    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Safe":
                Debug.Log("I'm ok");
                break;

            case "Finish":
                StartSuccessSequence();
                Debug.Log("YAAAAAY");
                break;

            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {   
        movement.enabled = false;
        audioSource.PlayOneShot(crashSFX);
        Invoke("ReloadLevel", loadDelay);
    }

    void StartSuccessSequence()
    {
        movement.enabled = false;
        audioSource.PlayOneShot(successSFX);
        Invoke("LoadNextLevel", loadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
