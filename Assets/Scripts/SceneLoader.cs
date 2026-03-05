using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadIndustryScene()
    {
        SceneManager.LoadScene("Industrial View");
    }
}