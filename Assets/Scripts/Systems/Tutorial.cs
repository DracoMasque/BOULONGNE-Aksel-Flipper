using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public bool onGoing = true;
    public GameObject paddleText;
    public GameObject itemHolder;
    public GameObject itemRecupText;
    public GameObject itemText;
    public GameObject portal;
    public GameObject portalText;
    
    public void PaddleInputTutoDone()
    {
        itemHolder.SetActive(true);
        paddleText.SetActive(false);
        itemRecupText.SetActive(true);
    }

    public void ItemTutorialDone()
    {
        itemText.SetActive(false);
        portal.SetActive(true);
        portalText.SetActive(true);
    }

    public void RecupItemDone()
    {
        itemText.SetActive(true);
        itemRecupText.SetActive(false);
    }
}
