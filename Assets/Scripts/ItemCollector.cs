using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public Health healthScript;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("GApple")) {
            Destroy(collision.gameObject);
            GameData.numOfHearts += 1;
        }
        else if (collision.gameObject.CompareTag("Apple") && GameData.health != GameData.numOfHearts * 2) {
            Destroy(collision.gameObject);
            GameData.health += 2;
        }
    }
}