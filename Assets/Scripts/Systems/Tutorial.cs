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

    [HideInInspector] public bool paddleInputTutoDone = true;
    [HideInInspector] public bool itemRecupTextDone = true;
    [HideInInspector] public bool itemTutorialDone = true;
    
    public void PaddleInputTutoDone()
    {
        itemHolder.SetActive(true);
        paddleText.SetActive(false);
        itemRecupText.SetActive(true);
        paddleInputTutoDone = false;
    }

    public void ItemTutorialDone()
    {
        itemText.SetActive(false);
        portal.SetActive(true);
        portalText.SetActive(true);
        itemTutorialDone = false;
    }

    public void RecupItemDone()
    {
        itemText.SetActive(true);
        itemRecupText.SetActive(false);
        itemRecupTextDone = false;
    }
}
