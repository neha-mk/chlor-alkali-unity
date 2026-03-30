using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance;

    public GameObject tooltipPanel;
    public TextMeshProUGUI tooltipText;

    void Awake()
    {
        Instance = this;
        tooltipPanel.SetActive(false);
    }

    public void ShowTooltip(string message)
    {
        tooltipPanel.SetActive(true);
        tooltipText.text = message;
    }

    public void HideTooltip()
    {
        tooltipPanel.SetActive(false);
    }

    void Update()
    {
        tooltipPanel.transform.position = Input.mousePosition + new Vector3(45, 105, 0);
    }
}