using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadIndustryScene()
    {
        SceneTracker.previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Industrial View");
    }
}