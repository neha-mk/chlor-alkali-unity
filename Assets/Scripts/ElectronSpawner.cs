using UnityEngine;

public class ElectronSpawner : MonoBehaviour
{
    public GameObject electronPrefab;
    public Transform[] pathPoints;

    public float spawnRate = 0.02f;   // faster spawning
    public float speed = 1f;

    public int maxElectrons = 200;

    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        int currentElectrons = GameObject.FindGameObjectsWithTag("Electron").Length;

        if (timer >= spawnRate && currentElectrons < maxElectrons)
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

        e.tag = "Electron";

        ElectronMover mover = e.AddComponent<ElectronMover>();
        mover.pathPoints = pathPoints;
        mover.speed = speed;
    }
}