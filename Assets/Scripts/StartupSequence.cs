using UnityEngine;
using System.Collections;

public class StartupSequence : MonoBehaviour
{
    public ParticleSystem[] liquidSystems;

    public ParticleSystem[] ionSystems;   // all ions
    public ParticleSystem[] gasSystems;

    void Start()
    {
        StartCoroutine(StartProcess());
    }

    IEnumerator StartProcess()
    {
        // 1️⃣ Start liquids immediately
        foreach (ParticleSystem ps in liquidSystems)
        {
            ps.Play();
        }

        // Wait 2 seconds
        yield return new WaitForSeconds(2f);

        // 2️⃣ Start Na+ and Cl-
        if (ionSystems.Length >= 0)
        {
            ionSystems[0].Play();
            ionSystems[1].Play();
            ionSystems[6].Play();// Na+
        }

        if (ionSystems.Length > 1)
        {
            ionSystems[2].Play();
            ionSystems[3].Play();
            ionSystems[7].Play();// Cl-
        }

        // Wait 1 second
        yield return new WaitForSeconds(1f);

        // 3️⃣ Start OH-
        if (ionSystems.Length > 2)
        {
            ionSystems[4].Play();
            ionSystems[5].Play();// OH-
        }

        // Wait 2 seconds
        yield return new WaitForSeconds(2f);

        // 4️⃣ Start gas bubbles
        foreach (ParticleSystem ps in gasSystems)
        {
            ps.Play();
        }
    }
}