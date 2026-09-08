using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public float targetPos = 75;
    public float originePos;
    
    public HingeJoint hinge;
    
    public KeyCode pressedKey = KeyCode.Space;
    
    private JointSpring  jointSpring;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jointSpring = hinge.spring;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PaddleAction(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            jointSpring.targetPosition = targetPos;
        }
        else
        {
            jointSpring.targetPosition = originePos;
        }
        hinge.spring = jointSpring;
    }
}
