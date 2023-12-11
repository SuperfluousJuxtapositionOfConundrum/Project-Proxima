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
                Invoke("StartSuccessSequence", loadDelay);
                Debug.Log("YAAAAAY");
                break;

            default:
                Invoke("StartCrashSequence", loadDelay);
                break;
        }
    }

    void StartCrashSequence()
    {

    }

    void StartSuccessSequence()
    {
        
    }
}
