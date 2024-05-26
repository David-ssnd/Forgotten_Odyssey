using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraTransition : MonoBehaviour
{
    public string targetSceneName = "TutorialScene"; // Name of the scene with the first level
    public float transitionSpeed = 5f;

    private bool isTransitioning = false;
    private Vector3 targetPosition;

    void Update()
    {
        if (isTransitioning)
        {
            // Interpolate the camera's position towards the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * transitionSpeed);

            // Additional logic for rotation or other effects if needed

            // Check if the camera has reached the target position with some tolerance
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isTransitioning = false;
            }
        }
    }

    public void StartTransition()
    {
        // Load the target scene if it's not already loaded
        if (!SceneManager.GetSceneByName(targetSceneName).isLoaded)
        {
            SceneManager.LoadScene(targetSceneName);
        }

        // Set the target position to the desired coordinates in the target scene
        // You may need to adjust this depending on your scene and camera setup
        targetPosition = new Vector3(-81.95f, -188.64f, 5.3355f); // Replace with the actual coordinates

        isTransitioning = true;
    }
}
