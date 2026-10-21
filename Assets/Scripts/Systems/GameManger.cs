using TMPro;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [SerializeField] private int lifeCount = 3;
    public GameObject ball;
    public TextMeshProUGUI lifeCountText;
    public Transform originePos;
    private Tutorial tuto;

    void Start()
    {
        tuto = gameObject.GetComponent<Tutorial>();
        RefreshLifeText();
    }

    public void LooseLife()
    {
        
        if (lifeCount > 0 && !tuto.onGoing)
        {
            lifeCount--;
            RefreshLifeText();
            SpawnBall();
        }
        else if (tuto.onGoing)
        {
            SpawnBall();
        }
    }
    
    void SpawnBall()
    {
        ball.transform.position = originePos.position;
    }
    
    void RefreshLifeText()
    {
        if (lifeCountText != null)
        {
            lifeCountText.text = "life : " + lifeCount;
        }
    }
    
}
