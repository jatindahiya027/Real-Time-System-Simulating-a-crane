using UnityEngine;


public class MaximizeWindow : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;  // Show the cursor
            Cursor.lockState = CursorLockMode.None; 
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Cursor.visible = false;  // Hide the cursor
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
