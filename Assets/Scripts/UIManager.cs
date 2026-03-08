using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    // for details info tooltip 
    public GameObject infoPanel;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    // for legend image
    public GameObject legendPanel;
    public Image legendImage;
    public Sprite particleLegendSprite;

    // for equations image
    public GameObject equationsPanel;
    public Image equationsImage;
    public Sprite equationsSprite;
    

    void Awake()
    {
        instance = this;
    }


    public void ShowInfo(string title, string description)
    {
        if (titleText.text == title && infoPanel.activeSelf)
        {
            titleText.text = "";
            descriptionText.text = "";
            infoPanel.SetActive(false);
            return;
        }
        Debug.Log("Showing info panel");
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

    public void ShowParticleLegend()
    {
        infoPanel.SetActive(false);
        equationsPanel.SetActive(false);
        // if legenPanel is already active, do nothing
        if(legendPanel.activeSelf)        {
            legendPanel.SetActive(false);
            legendImage.sprite = null;
            return;
        } 
        legendPanel.SetActive(true);
        legendImage.sprite = particleLegendSprite;
    }
    public void ShowEquations()
    {
        infoPanel.SetActive(false);
        legendPanel.SetActive(false);
        // if equationsPanel is already active, do nothing
        if(equationsPanel.activeSelf)        {
            equationsPanel.SetActive(false);
            equationsImage.sprite = null;
            return;
        } 
        equationsPanel.SetActive(true);
        equationsImage.sprite = equationsSprite;
    }
}