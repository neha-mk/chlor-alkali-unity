using UnityEngine;

public class CellClickDetector : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // if name contains "Electrical Equipment" then call fucntion
                if (hit.transform.name.Contains("Electrical Equipment") || hit.transform.name.Contains("Pipe Types New Pipe"))
                {
                    // Call your function here
                    Debug.Log("Electrical Equipment clicked!");
                }
            }
        }
    }
}