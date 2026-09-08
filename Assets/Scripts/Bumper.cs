using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Bumper : MonoBehaviour
{
    [Range(10.0f,50.0f)] public float strenght;
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 force;
        force = (collision.transform.position - transform.position).normalized*strenght;
        collision.rigidbody.AddForce(force, ForceMode.Impulse);
    }
}
