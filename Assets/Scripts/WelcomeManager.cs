using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeManager : MonoBehaviour
{
    public GameObject aboutPanel;
    public GameObject creditsPanel;

    //----------------------------------
    // START PROCESS
    //----------------------------------

    public void StartProcess()
    {
        SceneManager.LoadScene("Industrial View");
    }

    //----------------------------------
    // ABOUT
    //----------------------------------

    public void ShowAbout()
    {
        aboutPanel.SetActive(true);
    }

    public void CloseAbout()
    {
        aboutPanel.SetActive(false);
    }

    //----------------------------------
    // CREDITS
    //----------------------------------

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }

    //----------------------------------
    // EXIT
    //----------------------------------

    public void ExitApp()
    {
        Debug.Log("Exiting Application");

        Application.Quit();

        // For editor testing
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}