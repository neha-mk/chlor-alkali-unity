using UnityEngine;
using System.Collections;

public class UIEffects : MonoBehaviour
{
    public static UIEffects Instance;

    void Awake()
    {
        Instance = this;
    }

    public IEnumerator ButtonClickAnimation(Transform buttonTransform)
    {
        Vector3 originalScale = buttonTransform.localScale;
        Vector3 pressedScale = originalScale * 0.9f;

        float duration = 0.08f;
        float time = 0f;

        while (time < duration)
        {
            buttonTransform.localScale = Vector3.Lerp(originalScale, pressedScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        time = 0f;
        while (time < duration)
        {
            buttonTransform.localScale = Vector3.Lerp(pressedScale, originalScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        buttonTransform.localScale = originalScale;
    }
}