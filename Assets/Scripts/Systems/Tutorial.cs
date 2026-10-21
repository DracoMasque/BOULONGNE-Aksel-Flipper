using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public bool onGoing = true;
    public GameObject bumperHolder;
    public GameObject itemHolder;
    public GameObject portal;
    
    public void PaddleInputTutoDone()
    {
        bumperHolder.SetActive(true);
    }

    public void ItemTutorialDone()
    {
        portal.SetActive(true);
    }

    public void BumperTutorialDone()
    {
        itemHolder.SetActive(true);
    }

    public void RecupItemDone()
    {
        
    }
}
