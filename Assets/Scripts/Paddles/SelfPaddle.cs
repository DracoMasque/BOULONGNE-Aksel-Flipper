using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelfPaddle : MonoBehaviour
{
    
    private Camera mainCamera;
    private InputAction mousePos;
    private Animation anim;
    private GameObject ball;
    private Rigidbody rb;

    void Start()
    {
        mainCamera = Camera.main;
        anim = GetComponent<Animation>();
        mousePos = InputSystem.actions["MousePos"];
        ball = GameObject.FindWithTag("Ball");
        rb = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, MouseRotation());
    }
    
    public void SelfPaddleAction(InputAction.CallbackContext ctx)
    {   
        if (ctx.performed)
        {
            anim.Play();
        }
        
    }

    private float MouseRotation()
    {
        Vector3 rotation = mainCamera.ScreenToWorldPoint(mousePos.ReadValue<Vector2>()) - transform.position;
        return Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
    }

    public void PropulceBall()
    {
        print("Propulce ball");
        rb.AddForce(Vector3.forward * 1000, ForceMode.Impulse);
    }
    
}
