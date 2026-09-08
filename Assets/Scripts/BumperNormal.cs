using UnityEngine;

public class BumperNormal : MonoBehaviour
{
    [Range(10.0f,50.0f)] public float strenght;
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 force;
        force = -collision.contacts[0].normal*strenght;
        collision.rigidbody.AddForce(force, ForceMode.Impulse);
    }
}
