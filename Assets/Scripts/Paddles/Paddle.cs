using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public float targetPos = 75;
    public float originePos;
    
    public HingeJoint hinge;
    
    private JointSpring  jointSpring;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
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
        Debug.Log(hinge.spring);
    }
}

