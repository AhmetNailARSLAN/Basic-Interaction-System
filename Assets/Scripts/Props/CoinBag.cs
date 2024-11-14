using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBag : MonoBehaviour, IInteractable, IPickupable
{
    public void Interact()
    {
        //just to show for this example ****************************
        GameUIManager.Instance.coin += 10;
        Destroy(gameObject);
    }

    public void ShowInteractUI(bool val)
    {
        if (val)
        {
            GameUIManager.Instance.ShowInteractUI("Take Money");
        }
        else
        {
            GameUIManager.Instance.HideInteractUI();
        }
    }

    public void ShowPickupUI(bool val)
    {
        if (val)
        {
            GameUIManager.Instance.ShowPickupUI("Pickup Money Bag");
        }
        else
        {
            GameUIManager.Instance.HidePickupUI();
        }
    }
}
