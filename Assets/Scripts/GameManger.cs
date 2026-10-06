using TMPro;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [SerializeField] private int lifeCount = 3;
    public GameObject ball;
    public TextMeshProUGUI lifeCountText;
    public Transform originePos;

    void Start()
    {
        RefreshLifeText();
    }

    public void LooseLife()
    {
        
        if (lifeCount > 0)
        {
            lifeCount--;
            RefreshLifeText();
            SpawnBall();
        }
    }
    
    void SpawnBall()
    {
        Instantiate(ball, originePos.position, transform.rotation);
    }
    
    void RefreshLifeText()
    {
        lifeCountText.text = "life : " + lifeCount;
    }
    
}
