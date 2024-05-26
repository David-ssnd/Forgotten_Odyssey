using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 2f;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadPreviousLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        Debug.Log("Coroutine on");
        transition.SetTrigger("Start");
        Debug.Log("Anim done.");

        yield return new WaitForSeconds (transitionTime);
        Debug.Log("Changing scene");
        SceneManager.LoadScene(levelIndex);
        Debug.Log("Changed scene");
    }
}