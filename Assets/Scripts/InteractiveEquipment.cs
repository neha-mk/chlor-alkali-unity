using UnityEngine;

public class InteractiveEquipment : MonoBehaviour
{
    Renderer rend;
    Color originalColor;

    public Texture2D hoverCursor;

    public Color hoverColor = Color.yellow;

    EquipmentData data;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;

        data = GetComponent<EquipmentData>();
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
        Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);

        // SHOW TOOLTIP
        if (TooltipManager.Instance != null && data != null)
        {
            TooltipManager.Instance.ShowTooltip(data.equipmentName);
        }
    }

    void OnMouseExit()
    {
        rend.material.color = originalColor;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        if (TooltipManager.Instance != null)
        {
            TooltipManager.Instance.HideTooltip();
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Showing infoPanel cause InteractiveEquipment was clicked");

        UIManager.instance.ShowInfo(
            data.equipmentName,
            data.equipmentDescription
        );
    }
}