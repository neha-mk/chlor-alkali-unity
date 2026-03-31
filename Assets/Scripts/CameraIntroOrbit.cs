using UnityEngine;
using System.Collections;
public class CameraIntroOrbit : MonoBehaviour
{
    public Transform pivot;           // Center point to orbit
    public float orbitSpeed = 50f;    // Speed of rotation
    public float orbitDuration = 3f;  // How long the orbit lasts
    public float moveToFinalSpeed = 2f;

    private Vector3 finalPosition;
    private Quaternion finalRotation;

    private float timer = 0f;
    private bool orbiting = true;

    public AudioSource audioSource;
    public AudioClip transitionSound;

    void StartIntro()
    {
        orbiting = true;
        Debug.Log("Starting camera intro orbit");

        if (audioSource != null && transitionSound != null)
        {
            audioSource.clip = transitionSound;
            audioSource.time = 2f;
            audioSource.PlayOneShot(transitionSound);
            Debug.Log("Played transition sound");
        } else
        {
            Debug.LogWarning("AudioSource or TransitionSound not set on CameraIntroOrbit");
        }

        transform.position = pivot.position + new Vector3(0, 2, -10);
        transform.LookAt(pivot);

    }

    void SkipIntro()
    {
        orbiting = false;

        // Stay at final position
        transform.position = finalPosition;
        transform.rotation = finalRotation;

    }

    void Start()
    {
        finalPosition = transform.position;
        finalRotation = transform.rotation;
        // Only play intro if coming from Scene1
        if (SceneTracker.previousScene == "Welcome Scene")
        {
            StartIntro();
        }
        else
        {
            SkipIntro();
        }
    }

    void Update()
    {
        if (orbiting)
        {
            timer += Time.deltaTime;

            // Rotate around pivot
            transform.RotateAround(pivot.position, Vector3.up, orbitSpeed * Time.deltaTime);
            transform.LookAt(pivot);

            if (timer >= orbitDuration)
            {
                orbiting = false;
            }
        }
        else
        {
            // Smoothly move to final position
            transform.position = Vector3.Lerp(transform.position, finalPosition, Time.deltaTime * moveToFinalSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, finalRotation, Time.deltaTime * moveToFinalSpeed);
        }
    }
}