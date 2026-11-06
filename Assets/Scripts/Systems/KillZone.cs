using System;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Ball")
        {
            gameManager.SpawnBall();
            ScoreManager.instance.objectif = MathF.Round(ScoreManager.instance.objectif * 1.5f);
            ScoreManager.instance.AddScore(0);
        }
    }
}
