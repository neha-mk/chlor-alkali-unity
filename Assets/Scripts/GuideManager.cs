using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GuideManager : MonoBehaviour
{
    public static GuideManager Instance;

    public TextMeshProUGUI guideText;
    public GameObject guidePanel;

    string[] steps =
    {
        "Welcome to the Chlor-Alkali Electrolysis Plant.",
        "Move around and hover over the equipments. You can click on the equipments to view detailed information about them.",
        "You can also click on the 'Industrial Cell' to explore how chlor-alkali process works."
    };

    int currentStep = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        guideText.text = steps[currentStep];
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