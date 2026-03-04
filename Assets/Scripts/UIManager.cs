using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject infoPanel;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    void Awake()
    {
        instance = this;
    }

    public void ShowInfo(string title, string description)
    {
        if(infoPanel == null || titleText == null || descriptionText == null)
        {
            Debug.LogError("UIManager references not set!");
            return;
        }

        infoPanel.SetActive(true);
        titleText.text = title;
        descriptionText.text = description;
    }

    public void HideInfo()
    {
        Debug.Log("Hiding info panel");
        infoPanel.SetActive(false);
    }
}