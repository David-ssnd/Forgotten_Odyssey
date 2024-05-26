using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    //private EntryScene entryScene;
    public void StartGame() {
        GameData._sceneLoaded = false;
        SceneManager.LoadScene("Tutorial");
    }
}
