using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour, IPickupable
{
    public void ShowPickupUI(bool val)
    {
        if (val)
        {
            GameUIManager.Instance.ShowPickupUI("Pick Up Skull");
        }
        else
        {
            GameUIManager.Instance.HidePickupUI();
        }
    }

}
