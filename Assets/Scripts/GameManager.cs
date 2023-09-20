using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float killHeight;
    [SerializeField] private InputAction resetInput;

    private GameObject ballResource;
    private GameObject HUDResource;
    private GameObject mazeResource;

    private GameObject ballObject;
    private GameObject HUDObject;
    private GameObject mazeObject;

    private HUD HUDScript;
    private MazeController mazeController;


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
        mazeResource = Resources.Load<GameObject>("Maze");
    }
    private void CreateObjects()
    {
        ballObject = Instantiate(ballResource);
        HUDObject = Instantiate(HUDResource);
        mazeObject = Instantiate(mazeResource);


        HUDScript = HUDObject.GetComponent<HUD>();
        mazeController = mazeObject.GetComponent<MazeController>();
        BallController ballController = ballObject.GetComponent<BallController>();
        ballController.SetGameManager(this);

        mazeObject.transform.position = Vector3.zero;
        ballObject.transform.position = mazeController.GetSpawnPoint();
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
        ballObject.transform.position = mazeController.GetSpawnPoint();
        ballObject.SetActive(true);
        currentLives = 3;
        currentScore = 0;
    }



    public void KillPlayer()
    {
        ballObject.transform.position = mazeController.GetSpawnPoint();
        currentLives--;
        HUDScript.SetLives(currentLives);
        mazeController.ResetState();
    }
    public void AddScore(uint score)
    {
        currentScore += score;
        HUDScript.SetScore(currentScore);
    }
}
