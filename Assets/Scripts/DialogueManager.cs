using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Transform playerTransform;
    public LayerMask playerLayer;
    public float detectionRadius = 2f;

    // Define arrays to hold references to different canvases and texts
    public GameObject[] dialogueCanvases;
    public TextMeshProUGUI[] dialogueTexts;

    private bool isPlayerInRange = false;
    
    private string collidedTag;

    void Update()
    {
        CheckPlayerProximity();

        if (isPlayerInRange)
        {
            ShowDialogue();
        }
    }

    void CheckPlayerProximity()
    {
        Vector2 boxSize = new Vector2(detectionRadius * 2, detectionRadius * 2);

        Collider2D playerCollider = Physics2D.OverlapBox(playerTransform.position, boxSize, 0, playerLayer);

        if (playerCollider != null)
        {
            // Check the tag of the collided object
            collidedTag = playerCollider.gameObject.tag;

            isPlayerInRange = true;
        }
        else
        {
            isPlayerInRange = false;
            HideDialogue();
        }
    }

    void ShowDialogue()
    {
        if (collidedTag == "Tip4")
        {
            dialogueCanvases[0].SetActive(true);
            dialogueTexts[0].text = GetDialogueText(collidedTag);
        }
        else
        {
            for (int i = 0; i < dialogueCanvases.Length; i++)
            {
                if (collidedTag == "Tip" + (i + 1))
                {
                    dialogueCanvases[i].SetActive(true);
                    dialogueTexts[i].text = GetDialogueText(collidedTag);
                }
                else
                {
                    dialogueCanvases[i].SetActive(false);
                }
            }
        }
    }

    void HideDialogue()
    {
        // Disable all Canvases
        foreach (GameObject canvas in dialogueCanvases)
        {
            canvas.SetActive(false);
        }
    }

    // Add a method to get the appropriate dialogue text based on the tag
    string GetDialogueText(string tag)
    {
        switch (tag)
        {
            case "Tip1":
                return "Movement: WASD\nJump: Space";
            case "Tip2":
                return "Golden apples\ngive you\nbonus hearts!";
            case "Tip3":
                return "Red apples\nheal your\nhearts!";
            case "Tip4":
                Debug.Log("GDA");
                return "Coming soon!";
            // Add more cases for additional tips if needed
            default:
                return "Default Text";
        }
    }
}
