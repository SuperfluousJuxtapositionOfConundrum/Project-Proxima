using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{   
    [SerializeField] float loadDelay = 1f;

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
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.GetActiveScene(currentSceneIndex);
    }

    void StartSuccessSequence()
    {
        
    }
}
