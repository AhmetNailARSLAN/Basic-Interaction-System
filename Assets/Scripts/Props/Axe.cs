using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        GameUIManager.Instance.health -= 50;
    }

    public void ShowInteractUI(bool val)
    {
        if (val)
        {
            GameUIManager.Instance.ShowInteractUI("Interact");
        }
        else
        {
            GameUIManager.Instance.HideInteractUI();
        }
    }

}
