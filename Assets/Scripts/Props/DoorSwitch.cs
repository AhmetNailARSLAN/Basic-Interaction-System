using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class DoorSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] private Door door;
    Animator animator;

    private bool isOn = false;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    public void Interact()
    {
        if (!isOn)
        {
            SwitchOn();
        }
        else
        {
            SwitchOff();
        }
    }

    public void ShowInteractUI(bool val)
    {
        if (val)
        {
            if (!isOn)
            {
                GameUIManager.Instance.ShowInteractUI("Open Door");
            }
            else
            {
                GameUIManager.Instance.ShowInteractUI("Close Door");
            }

        }
        else
        {
            GameUIManager.Instance.HideInteractUI();
        }
    }
    private void SwitchOn()
    {
        animator.enabled = true;
        animator.SetTrigger("SwitchOn");
        door.OpenDoor();
        isOn = true;
    }

    private void SwitchOff()
    {
        animator.enabled = true;
        animator.SetTrigger("SwitchOff");
        door.CloseDoor();
        isOn = false;
    }


}
