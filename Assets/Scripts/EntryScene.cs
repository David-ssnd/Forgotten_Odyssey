using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;
using static System.TimeZoneInfo;
using UnityEngine.SceneManagement;

public class EntryScene : MonoBehaviour
{
    public GameObject darkBG;

    private Renderer playerRenderer;
    private Collider2D playerCollider;
    private SpriteRenderer playerSpriteRenderer;

    private Renderer ballRenderer;
    private Light2D ballLight;

    public int starts = 0;
    private bool ballDestroyed = false;

    private Rigidbody2D rb;
    [SerializeField] public WaypointFollowerCustom waypoint;
    [SerializeField] private CameraController cam;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ball;
    [SerializeField] private Canvas canvas;

    public Pulse pulse; // pulse.bloom.intensity.value = 18f;
    private ParticleSystem particleSys;
    public Animator transition;

    //Vector3 defaultPositiont = new Vector3(-12.9f, -6.63f, 0f); // default position of player
    Vector3 defaultPosition = new Vector3(-83.59f, -189.35f, 0f); // default position of player
    Vector3 cavePosition = new Vector3(25.82f, -161.32f, 0f);


    private enum ObjectState
    {
        FirstObjectMoving,
        FirstObjectStopped,
        SecondObjectMoving,
        SecondObjectStopped,
        off
    }

    private ObjectState currentState;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (GameData._sceneLoaded) 
        {
            player.transform.position = cavePosition;
            cam.startAnim = false;
            cam.canMove = true;
            Destroy(gameObject);
        }
        GameData._sceneLoaded = true;
    }
    void Start()
    {
        playerRenderer = player.GetComponent<Renderer>();
        playerCollider = player.GetComponent<Collider2D>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        ballRenderer = ball.GetComponent<Renderer>();
        ballLight = ball.GetComponentInChildren<Light2D>();
        currentState = ObjectState.FirstObjectMoving;
        cam = FindObjectOfType<CameraController>();
        rb = player.GetComponent<Rigidbody2D>();
        particleSys = ball.GetComponentInChildren<ParticleSystem>();
        canvas.enabled = false;
        DisableParticleSystem();
        HidePlayer();
        HideBall();
    }

    void Update()
    {
        // update logic based on object state
        switch (currentState)
        {
            case ObjectState.FirstObjectStopped:
                //Debug.Log("State: FirstObjectStopped");
                ShowBall();
                EnableParticleSystem();
                // Trigger movement for the second object
                waypoint.isMoving = true;
                currentState = ObjectState.SecondObjectMoving;
                //Debug.Log("State transition: FirstObjectStopped -> SecondObjectMoving");
                pulse.visible = true;
                break;

            case ObjectState.SecondObjectMoving:
                Debug.Log("Moving");
                break;

            case ObjectState.SecondObjectStopped:

                if (!ballDestroyed)
                {
                    Destroy(ball);
                    ballDestroyed = true;
                }

                ShowPlayer();
                Debug.Log("Player shown.");
                canvas.enabled = true;
                darkBG.SetActive(false);
                currentState = ObjectState.off;
                break;
            default:
                //Debug.Log("Unknown state: " + currentState);
                break;
        }
    }


    public void OnFirstObjectStopped()
    {
        currentState = ObjectState.FirstObjectStopped;
        Debug.Log("Received object stopped.");
    }

    public void OnSecondObjectStopped()
    {
        currentState = ObjectState.SecondObjectStopped;
        Debug.Log("Received object stopped. (2)");
    }

    public void HidePlayer()
    {
        playerRenderer.enabled = false;
        playerCollider.enabled = false;
       
    }

    public void ShowPlayer()
    {
        playerCollider.enabled = true;
        playerRenderer.enabled = true;
        Invoke("TeleportPlayer", 0.1f);
    }
    public void HideBall()
    {
        ballRenderer.enabled = false;

        if (ballLight != null)
        {
            ballLight.intensity = 0;
        }
    }

    public void ShowBall()
    {
        ballRenderer.enabled = true;

        if (ballLight != null)
        {
            ballLight.intensity = 0.94f;
        }
    }
    private void TeleportPlayer()
    {
        rb.velocity = Vector2.zero;
        player.transform.position = defaultPosition;
        Debug.Log("Player position set to default");
        cam.startAnim = false;
        cam.canMove = true;
    }
    void DisableParticleSystem()
    {
        particleSys.Stop(); // Stop emitting particles
        particleSys.Clear(); // Clear any existing particles
    }

    void EnableParticleSystem()
    {
        particleSys.Play(); // Start emitting particles
    }

    /*IEnumerator Waiting()
    {
        transition.SetTrigger("StartCut");

        yield return new WaitForSeconds(2f);

        ShowPlayer();
        Debug.Log("Player shown.");
        canvas.enabled = true;
        currentState = ObjectState.off;
        _sceneLoaded = true;
    }*/

}