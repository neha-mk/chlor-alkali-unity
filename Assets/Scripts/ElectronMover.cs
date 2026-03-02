using UnityEngine;

public class ElectronMover : MonoBehaviour
{
    public Transform[] pathPoints;
    public float speed = 2f;

    private int currentIndex = 0;

    void Update()
    {
        if (pathPoints == null || pathPoints.Length == 0)
            return;

        Transform target = pathPoints[currentIndex];

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            currentIndex++;

            if (currentIndex >= pathPoints.Length)
            {
                Destroy(gameObject);   // 🔥 Destroy at end
            }
        }
    }
}