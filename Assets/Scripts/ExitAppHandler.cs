using UnityEngine;

public class ExitAppHandler : MonoBehaviour
{
    public void ExitApplication()
    {
        Debug.Log("Application Closed");

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}