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

    [SerializeField] private GameObject paddle;

    [SerializeField] private int powerLevel = 0;
    [Range(5f,50.0f)] public float strenghtLevel1;
    [Range(5f,50.0f)] public float strenghtLevel2;
    [Range(5f,50.0f)] public float strenghtLevel3;
    public float strenght = 1;
    public GameObject point1;
    public GameObject point2;
    
    private bool timerLancer = false;
    private float timer = 0;

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
        if (timerLancer)
        {
            timer += Time.unscaledDeltaTime;
            ChangePower();
        }
    }
    
    public void SelfPaddleAction(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Time.timeScale = 0.5f;
            paddle.SetActive(true);
            timerLancer = true;
        }
        if (ctx.canceled)
        {
            anim.Play();
            Time.timeScale = 1;
            powerLevel = 0;
            timerLancer = false;
            timer = 0;
        }
        
    }

    private void ChangePower()
    {
        if (timer > 0.5f && powerLevel == 0)
        {
            powerLevel++;
            timer = 0;
            strenght = strenghtLevel1;
        }
        else if (timer > 1.5f && powerLevel == 1)
        {
            powerLevel++;
            timer = 0;
            strenght = strenghtLevel2;
        }
        else if (timer > 2.5f && powerLevel == 2)
        {
            powerLevel++;
            timer = 0;
            strenght = strenghtLevel3;
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
        Vector3 force;
        force = (point2.transform.position - point1.transform.position).normalized*strenght;
        rb.AddForce(force, ForceMode.Impulse);
    }
    
}
