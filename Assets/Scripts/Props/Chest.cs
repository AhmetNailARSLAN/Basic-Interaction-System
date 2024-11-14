using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    GameObject lid;
    Animator animator;

    bool isOpen = false;

    void Start()
    {
        lid = transform.GetChild(0).gameObject;

        animator = lid.GetComponent<Animator>();
    }

    public void Interact()
    {
        Debug.Log("Interact");

        if (!isOpen)
        {
            Debug.Log("Open chest");
            OpenChest();
        }
        else
        {
            CloseChest();
        }
    }

    public void ShowInteractUI(bool val)
    {
        if (val)
        {
            if (!isOpen)
            {
                GameUIManager.Instance.ShowInteractUI("Open Chest");
            }
            else
            {
                GameUIManager.Instance.ShowInteractUI("Close Chest");
            }

        }
        else
        {
            GameUIManager.Instance.HideInteractUI();
        }

    }

    private void OpenChest()
    {
        animator.enabled = true;
        animator.SetTrigger("OpenChest");
        isOpen = true;
    }

    private void CloseChest()
    {
        animator.SetTrigger("CloseChest");
        isOpen = false;
    }

}
