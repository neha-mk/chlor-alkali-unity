using UnityEngine;
using System.Collections;

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

        // SHOW TOOLTIP
        if (TooltipManager.Instance != null && data != null)
        {
            TooltipManager.Instance.ShowTooltip(data.equipmentName);
        }
        Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
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

    IEnumerator CameraShake()
    {
        Vector3 originalPos = transform.localPosition;

        float duration = 0.15f;   // slightly longer
        float magnitude = 0.05f;  // stronger shake

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            // Instant jump instead of smooth
            transform.localPosition = originalPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }   

    void OnMouseDown()
    {
        Debug.Log("Showing infoPanel cause InteractiveEquipment was clicked");

        // StartCoroutine(CameraShake());
        if (data.equipmentDescription != "")
        {
            UIManager.instance.ShowInfo(
                data.equipmentName,
                data.equipmentDescription
            );
        }

    }
}