using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private GameManger gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManger").GetComponent<GameManger>();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Ball")
        {
            gameManager.LooseLife();
        }
    }
}
