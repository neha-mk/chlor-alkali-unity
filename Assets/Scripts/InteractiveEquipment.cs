using UnityEngine;

public class InteractiveEquipment : MonoBehaviour
{
    Renderer rend;
    Color originalColor;

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
    }

    void OnMouseExit()
    {
        rend.material.color = originalColor;
    }

    void OnMouseDown()
    {
        UIManager.instance.ShowInfo(
            data.equipmentName,
            data.equipmentDescription
        );
    }
}