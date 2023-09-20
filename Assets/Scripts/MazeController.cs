using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MazeController : MonoBehaviour
{
    [SerializeField] private InputAction inputX;
    [SerializeField] private InputAction inputY;
    [SerializeField] private float tiltSpeed;


    void Awake()
    {
        inputX.Enable();
        inputY.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputX.triggered || inputY.triggered)
        {
            float xValue = inputX.ReadValue<float>();
            float yValue = inputY.ReadValue<float>();
            //Debug.Log(new Vector2(xValue, yValue));

            Vector3 currentRotation = transform.rotation.eulerAngles;
            //Debug.Log(currentRotation + " old");

            xValue *= Time.deltaTime * tiltSpeed;
            yValue *= Time.deltaTime * tiltSpeed;

            float newRotationX = -yValue * Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);
            float newRotationZ = -yValue * Mathf.Sin(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);

            Vector3 newRotation = currentRotation + new Vector3(
                newRotationX, 
                xValue, 
                newRotationZ);
            
            /*if (newRotation.x > 90.0f)
                newRotation.x = 90.0f;
            else if (newRotation.x < -90.0f)
                newRotation.x = -90.0f;*/

            //newRotation = new Vector3(newRotation.x, Mathf.Clamp(newRotation.y, -90f, 90f), 0f);
            //Debug.Log(newRotation + " new");
            transform.rotation = Quaternion.Euler(newRotation);
        }
    }
}
