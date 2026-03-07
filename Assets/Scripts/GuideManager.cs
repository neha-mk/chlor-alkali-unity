using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GuideManager : MonoBehaviour
{
    public TextMeshProUGUI guideText;
    public GameObject guidePanel;

    string[] steps =
    {
        "Welcome to the Chlor-Alkali Electrolysis Plant.",
        // "You can rotate the plant using the mouse.",
        // "Scroll to zoom in and out.",
        "Move around and hover over the equipments. You can click on the equipments to view detailed information about them.",
        "You can also click on the 'Industrial Cell' to explore how chlor-alkali process works."
    };

    int currentStep = 0;

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
}