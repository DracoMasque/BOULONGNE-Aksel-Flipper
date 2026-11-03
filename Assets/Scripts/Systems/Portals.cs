using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portals : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private SceneAsset targetScene;
    [SerializeField] private bool changeScene = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (changeScene)
            {
                SceneManager.LoadScene(targetScene.name);
            }
            else
            {
                other.transform.position = target.transform.position;
            }
        }
    }
    
    
}
