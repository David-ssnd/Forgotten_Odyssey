using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public CameraTransition cameraTransition;

    void Start()
    {
        // Assuming you've assigned the CameraTransition script in the inspector
        if (cameraTransition == null)
        {
            Debug.LogError("CameraTransition script not assigned!");
        }
    }

    public void OnPlayButtonClicked()
    {
        // Trigger the camera transition
        Debug.Log("Trigerred");
        cameraTransition.StartTransition();
    }
}