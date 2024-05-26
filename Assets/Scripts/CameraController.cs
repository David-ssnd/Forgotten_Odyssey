using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform empty;
    public bool canMove = false;
    public bool startAnim = true;

    private void Update()
    {
        if (startAnim && !canMove)
        {
            transform.position = new Vector3(empty.position.x, empty.position.y + 2.0f, transform.position.z);
        }

        if (canMove)
        {
            transform.position = new Vector3(player.position.x, player.position.y + 2.0f, transform.position.z);
        }
    }

private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Transition"))
        {
            canMove = false;
            Debug.Log("Cant move");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Transition"))
        {
            canMove = true;
            Debug.Log("Can move");
        }
    }
}
