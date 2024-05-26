using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public GameObject DarkBG;
    public void OnInventoryButtonClicked()
    {
        GameData._inventoryOpen = true;
        Time.timeScale = 0f;
        gameObject.SetActive(false);
        DarkBG.SetActive(true);
    }
}
