using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CellClickController : MonoBehaviour
{
    public Transform industrialCell;
    public Transform focusEquipment;

    public Transform cellCameraPoint;

    public float moveSpeed = 1.4f;
    public float liftHeight = 8.5f;

    bool animationRunning = false;

    void Update()
    {
        if (animationRunning) return;
    }

    public void TriggerCellView()
    {
        // your existing animation logic here
        // example:
        Debug.Log("Industrial Cell Clicked");

        StartCoroutine(CellSequence());
    }

    IEnumerator CellSequence()
    {
        animationRunning = true;

        // STEP 1 — Move camera to tank
        yield return MoveCamera(cellCameraPoint);


        // STEP 2 — Lift equipment upward slightly
        Debug.Log("Starting lift animation");

        Vector3 startPos = focusEquipment.localPosition;
        Vector3 targetPos = startPos + Vector3.up * liftHeight;

        float duration = 1.4f;
        float time = 0f;


        // If Electrolyzer is clicked
        if (GuideManager.Instance != null) {
            Debug.Log("Hiding guide");
            GuideManager.Instance.HideGuide();
        }

        while (time < duration)
        {
            focusEquipment.localPosition = Vector3.Lerp(startPos, targetPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        focusEquipment.localPosition = targetPos;

        Debug.Log("Lift complete");

        // STEP 3 — Rotate equipment 90 degrees
        Debug.Log("Starting rotation");

        Quaternion startRot = focusEquipment.localRotation;
        Quaternion targetRot = startRot * Quaternion.Euler(0, 32, 0); // rotate 90° on Y

        float rotDuration = 1.2f;
        float rotTime = 0f;

        while (rotTime < rotDuration)
        {
            focusEquipment.localRotation = Quaternion.Slerp(startRot, targetRot, rotTime / rotDuration);
            rotTime += Time.deltaTime;
            yield return null;
        }

        focusEquipment.localRotation = targetRot;

        Debug.Log("Rotation complete");
        

        // STEP 6 — Load Scene 2
        SceneManager.LoadScene("Cell View");
    }

    IEnumerator MoveCamera(Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * moveSpeed);
            yield return null;
        }
    }
}