using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Start()
    {
        // Lock the cursor to the center and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
