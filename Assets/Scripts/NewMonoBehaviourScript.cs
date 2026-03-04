using UnityEngine;
using UnityEngine.SceneManagement;

public class TankClickLoader : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Tank clicked!");
        SceneManager.LoadScene("Welcome Scene");
    }
}