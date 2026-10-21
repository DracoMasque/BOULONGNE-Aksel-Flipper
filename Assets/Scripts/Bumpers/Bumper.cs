using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Bumper : MonoBehaviour
{
    [Range(10.0f,50.0f)] public float strenght;
    public Animation animation;
    public int score = 10;
    [SerializeField] private Tutorial tuto;
    
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 force;
        force = (collision.transform.position - transform.position).normalized*strenght;
        collision.rigidbody.AddForce(force, ForceMode.Impulse);
        
        if(ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(score);
        }
        
        animation.Play();
        if (tuto != null && tuto.onGoing)
        {
            tuto.BumperTutorialDone();
        }
    }
}
