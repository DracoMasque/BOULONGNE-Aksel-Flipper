using UnityEngine;

public class FollowBall : MonoBehaviour
{
    private GameObject ball;
    public bool canMove = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball = GameObject.FindWithTag("Ball");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove == true)
        {
            Follow();
        }
    }

    public void Follow()
    {
    
            gameObject.transform.position = ball.transform.position;
    }
}
