using UnityEngine;

public class ObstacleDeplacement : MonoBehaviour
{
    [SerializeField] private GameObject originePoint;
    [SerializeField] private GameObject targetPoint;
    public float speed = 1;
    public bool repetable;
    public bool moving;

    public void StartMove()
    {
        moving = true;
    }

    void Update()
    {
        if (moving)
        {
            if (repetable)
            {
                Vector3 direction = targetPoint.transform.position - transform.position;
                direction.Normalize();
                transform.position += direction * (speed * Time.deltaTime);
            }
            else if (transform.position != targetPoint.transform.position)
            {
                Vector3 direction = targetPoint.transform.position - transform.position;
                direction.Normalize();
                transform.position += direction * (speed * Time.deltaTime);
            }
            
        }
    }
    
}
