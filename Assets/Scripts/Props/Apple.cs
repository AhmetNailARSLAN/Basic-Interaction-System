using UnityEngine;

public class Apple : MonoBehaviour, IInteractable, IPickupable
{

    public void Interact()
    {
        //just to show for this example ****************************
        GameUIManager.Instance.health -= 10;
        Destroy(gameObject);
    }

    public void ShowInteractUI(bool val)
    {
        if (val)
        {
            GameUIManager.Instance.ShowInteractUI("Eat Apple");
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
            GameUIManager.Instance.ShowPickupUI("Pickup Apple");
        }
        else
        {
            GameUIManager.Instance.HidePickupUI();
        }
    }
}
