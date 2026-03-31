using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.EventSystems;

public class WelcomeManager : MonoBehaviour
{
    public GameObject aboutPanel;
    public GameObject creditsPanel;


    //----------------------------------
    // START PROCESS
    //----------------------------------

    public void ButtonClickAnimation()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        Debug.Log("UIEffects.Instance: " + UIEffects.Instance);

        // Not working right now
        if (clickedButton != null && UIEffects.Instance != null)
        {
            Debug.Log("HAHA");
            StartCoroutine(UIEffects.Instance.ButtonClickAnimation(clickedButton.transform));
        }
    }

    // private IEnumerator PlaySoundAndLoad(string sceneName)
    // {
    //     Debug.Log("Playing transition sound to load scene");
    //     SceneTracker.previousScene = SceneManager.GetActiveScene().name;
    //     if (audioSource != null && transitionSound != null)
    //     {
    //         Debug.Log("Playing transition sound");
    //         audioSource.PlayOneShot(transitionSound);
    //         yield return new WaitForSeconds(transitionSound.length);
    //     }

    //     SceneManager.LoadScene(sceneName);
    // }
    public void StartProcess()
    {
        SceneTracker.previousScene = SceneManager.GetActiveScene().name;
        // StartCoroutine(PlaySoundAndLoad("Industrial View"));
        SceneManager.LoadScene("Industrial View");
    }

    //----------------------------------
    // ABOUT
    //----------------------------------

    public void ShowAbout()
    {
        ButtonClickAnimation();
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
        ButtonClickAnimation();
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
        ButtonClickAnimation();

        Debug.Log("Exiting Application");

        Application.Quit();

        // For editor testing
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}