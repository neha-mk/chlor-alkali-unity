using UnityEngine;
using System.Collections;

public class StartupSequence : MonoBehaviour
{
    public ParticleSystem[] liquidSystems;
    public ParticleSystem[] ionSystems;
    public ParticleSystem[] gasSystems;
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(StartProcess());
    }

    IEnumerator StartProcess()
    {
        //----------------------------------
        // 1️⃣ Liquids
        //----------------------------------

        foreach (ParticleSystem ps in liquidSystems)
        {
            ps.Play();
        }

        yield return new WaitForSeconds(2f);

        //----------------------------------
        // 2️⃣ Na+ and Cl-
        //----------------------------------

        if (ionSystems.Length > 0)
        {
            ionSystems[0].Play();
            ionSystems[1].Play();
            if (ionSystems.Length > 6) ionSystems[6].Play();
        }

        if (ionSystems.Length > 1)
        {
            ionSystems[2].Play();
            ionSystems[3].Play();
            if (ionSystems.Length > 7) ionSystems[7].Play();
        }

        yield return new WaitForSeconds(1f);

        //----------------------------------
        // 3️⃣ OH-
        //----------------------------------

        if (ionSystems.Length > 4)
        {
            ionSystems[4].Play();
            ionSystems[5].Play();
        }

        yield return new WaitForSeconds(2f);

        //----------------------------------
        // 4️⃣ Gas bubbles
        //----------------------------------

        foreach (ParticleSystem ps in gasSystems)
        {
            ps.Play();
        }

        //----------------------------------
        // 🔊 Sound
        //----------------------------------

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}