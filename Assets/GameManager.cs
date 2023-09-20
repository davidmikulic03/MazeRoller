using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float killHeight;

    private GameObject ballResource;
    private GameObject HUDResource;




    private GameObject ballObject;
    private GameObject HUDObject;

    private HUD HUDScript;

    private bool gameOver = false;

    private uint currentLives = 3;


    void Awake()
    {
        LoadResources();
        CreateObjects();
    }

    void Update()
    {
        if (gameOver)
        {
            //Check input for reset 
            return;
        }

        CheckKillBounds();

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


    private void CheckKillBounds()
    {
        if (ballObject.transform.position.y <= killHeight)
        {
            KillPlayer();
            if (currentLives == 0)
                gameOver = true;
        }
    }
    private void KillPlayer()
    {
        ballObject.transform.position = spawnPosition;
        currentLives--;
        HUDScript.SetLives(currentLives);
    }
}
