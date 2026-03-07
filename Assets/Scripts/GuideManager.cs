using UnityEngine;
using TMPro;

public class GuideManager : MonoBehaviour
{
    public static GuideManager Instance;

    public TextMeshProUGUI guideText;
    public GameObject guidePanel;

    [TextArea(2,5)]
    public string[] steps;   // Now editable per scene in Inspector

    int currentStep = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (steps.Length > 0)
        {
            guideText.text = steps[currentStep];
        }
    }

    public void NextStep()
    {
        currentStep++;

        if (currentStep >= steps.Length)
        {
            guidePanel.SetActive(false);
            return;
        }

        guideText.text = steps[currentStep];
    }

    public void SkipTutorial()
    {
        guidePanel.SetActive(false);
    }

    public void HideGuide()
    {
        guidePanel.SetActive(false);
    }
}