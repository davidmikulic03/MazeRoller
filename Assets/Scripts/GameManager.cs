using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject ballResource;
    private GameObject ballObject;
    [SerializeField] private Vector3 initialPosition;

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
        ballResource = GameObject.Find("Ball");
    }

    private void CreateObjects()
    {
        ballObject = Instantiate(ballResource);
        BallController ballController = ballObject.GetComponent<BallController>();
        ballController.SetGameManager(this);
    }
}
