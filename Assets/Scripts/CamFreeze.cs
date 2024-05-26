using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFreeze : MonoBehaviour
{
    public CameraController cameraController;
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    private void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CamFreeze"))
        {
            cameraController.startAnim = false;
            cameraController.canMove = false;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CamFreeze"))
        {
            cameraController.startAnim = false;
            cameraController.canMove = true;
        }
    }
}
