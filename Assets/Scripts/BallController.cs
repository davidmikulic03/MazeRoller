using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private GameManager gameManager;




    public void SetGameManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    private void OnTriggerEnter(Collider collider)
    {
        
    }
}
