using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBGButton : MonoBehaviour
{
    public GameObject InventoryButton;
    public void OnDarkBGButtonClicked()
    {
        GameData._inventoryOpen = false;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        InventoryButton.SetActive(true);
    }
}
