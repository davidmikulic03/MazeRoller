using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MazeController : MonoBehaviour
{
    [SerializeField] private InputAction inputX;
    [SerializeField] private InputAction inputY;
    [SerializeField] private float tiltSpeed;

    private Transform spawnPoint;


    void Awake()
    {
        inputX.Enable();
        inputY.Enable();

        spawnPoint = transform.Find("SpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (inputX.triggered || inputY.triggered)
        {
            float xValue = inputX.ReadValue<float>();
            float yValue = inputY.ReadValue<float>();

            Vector3 currentRotation = transform.localRotation.eulerAngles;

            xValue *= Time.deltaTime * tiltSpeed;
            yValue *= Time.deltaTime * tiltSpeed;

            
            float newRotationX = -yValue * Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);
            float newRotationZ = -yValue * Mathf.Sin(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);

            /*Vector3 newRotation = currentRotation + new Vector3(
                newRotationX, 
                -xValue, 
                newRotationZ);

            transform.rotation = Quaternion.Euler(newRotation);*/
            

            transform.localRotation = Quaternion.Euler(new Vector3(currentRotation.x - yValue, currentRotation.y, currentRotation.z + xValue));
        }
    }

    public void ResetState()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
    public Vector3 GetSpawnPoint()
    {
        return spawnPoint.position;
    }
}
