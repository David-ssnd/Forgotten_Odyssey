using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentLevel : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        UpdateSceneName();
    }

    void UpdateSceneName()
    {
        textMeshProUGUI.text = SceneManager.GetActiveScene().name;
    }
}
