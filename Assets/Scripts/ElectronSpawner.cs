using UnityEngine;

public class ElectronSpawner : MonoBehaviour
{
    public GameObject electronPrefab;
    public Transform[] pathPoints;

    public float spawnRate = 0.2f;   // time between spawns
    public float speed = 2f;

    private float timer = 0f;

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