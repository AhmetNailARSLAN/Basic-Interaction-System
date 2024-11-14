using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        animator.enabled = true;
        animator.SetTrigger("OpenDoor");
    }

    public void CloseDoor()
    {
        animator.SetTrigger("CloseDoor");
    }


}
