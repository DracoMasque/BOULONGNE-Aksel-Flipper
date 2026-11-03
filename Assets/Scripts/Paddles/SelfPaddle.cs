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
    private RecupItem propulsionItems;
    [SerializeField] private Tutorial tuto;

    [SerializeField] private GameObject paddle;
    private Material paddleMaterial;

    [SerializeField] private int powerLevel = 1;
    [Range(5f,50.0f)] public float strenghtLevel1;
    [Range(5f,50.0f)] public float strenghtLevel2;
    [Range(5f,50.0f)] public float strenghtLevel3;
    [HideInInspector] public float strenght = 1;
    public GameObject point1;
    public GameObject point2;

    [SerializeField] [Range(0, 1f)] private float scaleTime;
    
    private bool timerLancer = false;
    private float timer = 0;
    private bool canShoot = false;

    void Start()
    {
        mainCamera = Camera.main;
        anim = GetComponent<Animation>();
        mousePos = InputSystem.actions["MousePos"];
        ball = GameObject.FindWithTag("Ball");
        rb = ball.GetComponent<Rigidbody>();
        propulsionItems = ball.GetComponent<RecupItem>();
        strenghtLevel1 = strenght;
        paddleMaterial = paddle.transform.GetChild(0).GetComponent<MeshRenderer>().material;
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
        if (propulsionItems.propultionItems.Count > 0)
        {
            if (ctx.started)
            {
                paddleMaterial.color = Color.red;
                Time.timeScale = scaleTime;
                paddle.SetActive(true);
                timerLancer = true;
                canShoot = true;
                propulsionItems.propultionItems[^1].SetActive(true);
                propulsionItems.propultionItems.RemoveAt(propulsionItems.propultionItems.Count-1);
            }
        }
        if (ctx.canceled && canShoot)
        {
            anim.Play();
            Time.timeScale = 1;
            powerLevel = 1;
            strenght = strenghtLevel1;
            timerLancer = false;
            timer = 0;
            canShoot  = false;
            if (tuto != null && tuto.itemTutorialDone)
            {
                tuto.ItemTutorialDone();
            }
        }
        
    }

    private void ChangePower()
    {
        if (timer > 1.5f && powerLevel == 1)
        {
            powerLevel++;
            strenght = strenghtLevel2;
            paddleMaterial.color = Color.yellow;
        }
        else if (timer > 2.5f && powerLevel == 2)
        {
            powerLevel++;
            strenght = strenghtLevel3;
            paddleMaterial.color = Color.green;
        }
    }

    private float MouseRotation()
    {
        Vector3 rotation = mainCamera.ScreenToWorldPoint(mousePos.ReadValue<Vector2>()) - transform.position;
        return Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
    }

    public void PropulceBall()
    {
        Vector3 force;
        force = (point2.transform.position - point1.transform.position).normalized*strenght;
        rb.AddForce(force, ForceMode.Impulse);
    }
    
}
