using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        // Quits the application
        Application.Quit();

        // If we are running in the Unity editor
#if UNITY_EDITOR
        // Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
