using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static Health instance;

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    void Update()
    {
        health = GameData.health;
        numOfHearts = GameData.numOfHearts;

        for (int i = 0; i < hearts.Length; i++)
        {
            int heartState = (i + 1) * 2;

            if (health > numOfHearts * 2)
            {
                health = numOfHearts * 2;
            }

            if (health >= heartState)
            {
                hearts[i].sprite = fullHeart;
            }
            else if (health >= heartState - 1)
            {
                hearts[i].sprite = halfHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            GameData.health = health;
            GameData.numOfHearts = numOfHearts;
            // Enable or disable the hearts based on the current index and numOfHearts
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        GameData.health = health;
        GameData.numOfHearts = numOfHearts;
    }
}
