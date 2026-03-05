using UnityEngine;

public class ElectronSpawner : MonoBehaviour
{
    public GameObject electronPrefab;
    public Transform[] pathPoints;

    public float spawnRate = 0.09f;   // constant electron count
    public float speed = 1f;

    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnElectron();
            timer = 0f;
        }
    }

    void SpawnElectron()
    {
        GameObject e = Instantiate(
            electronPrefab,
            pathPoints[0].position,
            Quaternion.identity
        );

        ElectronMover mover = e.AddComponent<ElectronMover>();
        mover.pathPoints = pathPoints;
        mover.speed = speed;
    }
}