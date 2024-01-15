using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    public float Maxtime = 2f; // Max time interval between spawns
    //public float maxY, minY;
    private float currentTime; // To track the time since the last spawn
    public float obstacle_speed = 3f;
     
    void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            SpawnLoop();
        }
    }

    public void SpawnLoop()
    {
        // Increment the timer
        currentTime += Time.deltaTime;


        // Check if it's time to spawn a new obstacle
        if (currentTime >= Maxtime)
        {
            Spawn();
            // Reset the timer and set the next spawn interval
            currentTime = 0f;
        }

    }
    public void Spawn()
    {
        GameObject obstacle_spawn = obstaclePrefabs[Random.Range(0,obstaclePrefabs.Length)];
        // Vector3 spawnposition = new Vector3(transform.position.x, Random.Range(minY, maxY), 0);
        GameObject spawned_obstacle = Instantiate(obstacle_spawn, transform.position, Quaternion.identity);

    }


}
