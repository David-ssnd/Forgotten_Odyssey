using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTrigger : MonoBehaviour
{
    public Sprite newBackground; // Assign the new background sprite in the Inspector

    private SpriteRenderer backgroundRenderer;
    private Sprite originalBackground;

    private void Start()
    {
        backgroundRenderer = GameObject.Find("Background").GetComponent<SpriteRenderer>();
        originalBackground = backgroundRenderer.sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeBackground();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RevertBackground();
        }
    }

    private void ChangeBackground()
    {
        if (newBackground != null)
        {
            backgroundRenderer.sprite = newBackground;
        }
    }

    private void RevertBackground()
    {
        backgroundRenderer.sprite = originalBackground;
    }
}
