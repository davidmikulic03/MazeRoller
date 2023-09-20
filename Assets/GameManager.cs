using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject ballResource;
    private GameObject HUDResource;




    private GameObject ballObject;
    private GameObject HUDObject;

    private HUD HUDScript;


    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float killHeight;


    private uint currentLives = 3;


    void Awake()
    {
        LoadResources();
        CreateObjects();
    }

    void Update()
    {
        
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

    private void KillPlayer()
    {
        if (ballObject.transform.position.y <= killHeight)
        {
            ballObject.transform.position = spawnPosition;
            currentLives--;
            HUDScript.SetLives(currentLives);
            //If game is over!
        }
    }
}
