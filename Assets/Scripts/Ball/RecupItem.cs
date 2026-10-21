using System;
using System.Collections.Generic;
using UnityEngine;

public class RecupItem : MonoBehaviour
{
    public List<GameObject> propultionItems;
    private Tutorial tuto;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PropultionItem")
        {
            propultionItems.Add(other.gameObject);
            other.gameObject.SetActive(false);
            if (tuto != null)
            {
                tuto.RecupItemDone();
            }
        }
    }
}
