using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;


public class Interactor : MonoBehaviour
{
    IInteractable currentInteractable;
    IPickupable currentPickupable;

    public LayerMask interactableLayerMask;
    Camera playerCamera;
    Ray ray;
    public float interactionDistance = 4f;

    GameObject pickedUpObject;
    public Transform playerHand;


    void Start()
    {
        playerCamera = Camera.main;

    }

    private void Update()
    {
        CheckForInteractable();

        if (pickedUpObject != null && Input.GetKeyDown(KeyCode.G))
        {
            TryDrop();
        }
    }

    private void CheckForInteractable()
    {
        ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactableLayerMask))
        {
            HandleInteractable(hit);
        }
        else
        {
            ClearInteractable();
            ClearPickupable();
        }
    }

    private void HandleInteractable(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent(out IInteractable interactable))
        {
            if (currentInteractable != null && currentInteractable != interactable)
            {
                currentInteractable.ShowInteractUI(false);
            }

            currentInteractable = interactable;
            currentInteractable.ShowInteractUI(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                TryInteract(interactable);
            }
        }
        if (hit.collider.TryGetComponent(out IPickupable pickupable))
        {
            if (currentPickupable != null && currentPickupable != pickupable)
            {
                currentPickupable.ShowPickupUI(false);
            }

            currentPickupable = pickupable;
            currentPickupable.ShowPickupUI(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                TryPickup(hit.collider.gameObject);
            }
        }
    }

    private void ClearInteractable()
    {
        if (currentInteractable != null)
        {
            currentInteractable.ShowInteractUI(false);
            currentInteractable = null;
        }
    }
    private void ClearPickupable()
    {
        if (currentPickupable != null)
        {
            currentPickupable.ShowPickupUI(false);
            currentPickupable = null;
        }
    }
        
    private void TryInteract(IInteractable interactable)
    {
        interactable.Interact();
    }
    private void TryPickup(GameObject obj)
    {
        if (pickedUpObject == null)
        {
            obj.GetComponent<Rigidbody>().isKinematic = true;
            obj.GetComponent<Collider>().enabled = false;

            pickedUpObject = obj.gameObject;
            pickedUpObject.transform.SetParent(playerHand);
            pickedUpObject.transform.localPosition = Vector3.zero;

            GameUIManager.Instance.ShowDropUI();
        }

    }
    private void TryDrop()
    {
        pickedUpObject.GetComponent<Rigidbody>().isKinematic = false; ;
        pickedUpObject.GetComponent<Collider>().enabled = true;


        pickedUpObject.transform.SetParent(null);
        pickedUpObject = null;

        GameUIManager.Instance.HideDropUI();
    }
}
