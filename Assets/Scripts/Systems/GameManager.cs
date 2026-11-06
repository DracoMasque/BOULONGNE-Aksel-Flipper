using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int lifeCount = 3;
    public GameObject ball;
    public TextMeshProUGUI lifeCountText;
    public Transform originePos;

    void Start()
    {
        SpawnBall();
    }
    
    public void SpawnBall()
    {
        ball.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        ball.transform.position = originePos.position;
    }
    
    
}
