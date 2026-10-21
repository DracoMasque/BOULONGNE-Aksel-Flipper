using UnityEngine;

public class BumperNormal : MonoBehaviour
{
    [Range(10.0f,50.0f)] public float strenght;
    [SerializeField] private Tutorial tuto;
    public int score = 10;
    
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 force;
        force = -collision.contacts[0].normal*strenght;
        collision.rigidbody.AddForce(force, ForceMode.Impulse);
        
        if(ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(score);
        }
        
        if (tuto != null && tuto.onGoing)
        {
            tuto.BumperTutorialDone();
        }
    }
}
