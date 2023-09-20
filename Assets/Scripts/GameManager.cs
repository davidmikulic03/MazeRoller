using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float killHeight;
    [SerializeField] private InputAction resetInput;

    private GameObject ballResource;
    private GameObject HUDResource;

    private GameObject ballObject;
    private GameObject HUDObject;

    private HUD HUDScript;


    private bool running = true;

    private uint currentLives = 3;
    private uint currentScore = 0;

    void Awake()
    {
        LoadResources();
        CreateObjects();
        resetInput.Enable();
    }

    void Update()
    {
        if (!running)
        {
            CheckInput();
            return;
        }

        CheckKillBounds();
        //UpdatePlayer
    }

    private void LoadResources()
    {
        ballResource = Resources.Load<GameObject>("Ball");
        HUDResource = Resources.Load<GameObject>("HUD");
    }
    private void CreateObjects()
    {
        ballObject = Instantiate(ballResource);
        HUDObject = Instantiate(HUDResource);
        HUDScript = HUDObject.GetComponent<HUD>();
        BallController ballController = ballObject.GetComponent<BallController>();
        ballController.SetGameManager(this);
    }


    private void CheckInput()
    {
        if (resetInput.triggered)
            ResetGameState();
    }
    private void CheckKillBounds()
    {
        if (ballObject.transform.position.y <= killHeight)
        {
            KillPlayer();
            if (currentLives == 0)
            {
                ballObject.SetActive(false);
                running = false;
            }
        }

    }
    private void ResetGameState()
    {
        running = true;
        ballObject.transform.position = spawnPosition;
        ballObject.SetActive(true);
    }



    public void KillPlayer()
    {
        ballObject.transform.position = spawnPosition;
        currentLives--;
        HUDScript.SetLives(currentLives);
    }
    public void AddScore(uint score)
    {
        currentScore += score;
        HUDScript.SetScore(currentScore);
    }
}
