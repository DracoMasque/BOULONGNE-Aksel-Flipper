using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnterEvent;
    [SerializeField] UnityEvent onTriggerExitEvent;
    [SerializeField] UnityEvent onCollisionEnterEvent;
 
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
    
        onTriggerEnterEvent.Invoke();
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        onTriggerExitEvent.Invoke();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        onCollisionEnterEvent.Invoke();
    }
}
