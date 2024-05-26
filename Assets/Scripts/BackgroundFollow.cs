using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform background; // Assign the background object in the Inspector
    public float smoothSpeed = 0.125f; // Adjust the smoothness of the movement
    public Sprite newBackground; // Assign the new background sprite in the Inspector

    private SpriteRenderer backgroundRenderer;
    private Sprite originalBackground;

    private bool isInTriggerZone = false;

    void Start()
{
    backgroundRenderer = background.GetComponent<SpriteRenderer>();
    originalBackground = backgroundRenderer.sprite;
}

    void Update()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, background.position.z);
        background.position = Vector3.Lerp(background.position, targetPosition, smoothSpeed * Time.deltaTime);
    }

    // Called when another collider enters the trigger zone
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BackgroundTrigger"))
        {
            ChangeBackground();
        }
    }

    // Called when another collider exits the trigger zone
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("BackgroundTrigger"))
        {
            RevertBackground();
        }
    }

    private void ChangeBackground()
{
    if (backgroundRenderer != null && newBackground != null)
    {
        backgroundRenderer.sprite = newBackground;
    }
}

private void RevertBackground()
{
    if (backgroundRenderer != null && originalBackground != null)
    {
        backgroundRenderer.sprite = originalBackground;
    }
}

}
