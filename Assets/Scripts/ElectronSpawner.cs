using UnityEngine;

public class ElectronSpawner : MonoBehaviour
{
    public GameObject electronPrefab;
    public Transform[] pathPoints;

    public float spawnRate = 0.09f;
    public float speed = 1f;

    // 🔥 ADD THIS
    public float startDelay = 3f;   // adjust this as needed

    float timer = 0f;
    float delayTimer = 0f;
    bool canSpawn = false;

    void Update()
    {
        // 🔥 HANDLE DELAY FIRST
        if (!canSpawn)
        {
            delayTimer += Time.deltaTime;

            if (delayTimer >= startDelay)
            {
                canSpawn = true;
            }
            return;
        }

        //----------------------------------
        // NORMAL SPAWNING
        //----------------------------------

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