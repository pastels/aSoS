using UnityEngine;

public class ScreenshotTaker : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // Press 'P' to take a screenshot
        {
            string path = Application.persistentDataPath + "/screenshot.png";
            ScreenCapture.CaptureScreenshot(path);
            Debug.Log("Screenshot saved to: " + path);
        }
    }
}
