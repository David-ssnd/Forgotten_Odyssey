using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void RestartGame()
    {
        GameData.health = 4;
        GameData.numOfHearts = 2;
        SceneManager.LoadScene("Tutorial");
    }
}