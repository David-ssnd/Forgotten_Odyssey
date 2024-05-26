using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using TMPro;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [Header("UI")]
    public Image image;
    public TextMeshProUGUI countText;

    [HideInInspector] public Item item;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;

    public void InitializeItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GameData._inventoryOpen == true)
        {
            image.raycastTarget = false;
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GameData._inventoryOpen == true)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (GameData._inventoryOpen == true)
        {
            image.raycastTarget = true;
            transform.SetParent(parentAfterDrag);
        }
    }
}
