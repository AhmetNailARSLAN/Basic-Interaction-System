using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;

    [Header("Interact UI")]
    [SerializeField] private GameObject interactUI; // Interact Panel
    [SerializeField] private TextMeshProUGUI interactText; // Interact Text

    [Header("Pickup UI")]
    [SerializeField] private GameObject pickupUI; // Pickup UI
    [SerializeField] private TextMeshProUGUI pickupText; // Pickup Text

    [Header("Drop UI")]
    [SerializeField] private GameObject dropUI; // Drop UI

    [Header("Character stats")]
    [SerializeField] private TextMeshProUGUI healthText; // Health Text
    [SerializeField] private TextMeshProUGUI coinText; // Coin Text



    //just to show for this example ****************************
    public int coin;
    public int health;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        //just to show for this example ****************************
        healthText.text = $"Health: {health}";
        coinText.text = $"Coin: {coin}";

    }

    #region Interact UI

    public void ShowInteractUI(string desc)
    {
        interactUI.SetActive(true);

        interactText.text = desc;
    }

    public void HideInteractUI()
    {
        interactUI.SetActive(false);
    }

    #endregion

    #region Pickup UI

    public void ShowPickupUI(string desc)
    {
        pickupUI.SetActive(true);
        pickupText.text = desc;
    }
    public void HidePickupUI()
    {
        pickupUI.SetActive(false);
    }

    #endregion

    #region Drop UI

    public void ShowDropUI()
    {
        dropUI.SetActive(true);
    }

    public void HideDropUI()
    {
        dropUI.SetActive(false);
    }

    #endregion

}
