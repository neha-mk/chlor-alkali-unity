using UnityEngine;

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

    void Start()
    {
        finalPosition = transform.position;
        finalRotation = transform.rotation;

        // Move camera back a bit to start orbit
        transform.position = pivot.position + new Vector3(0, 2, -10);
        transform.LookAt(pivot);
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