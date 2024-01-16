using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    //[SerializeField] private Transform obstacleParent;    
    private float currentTime; // To track the time since the last spawn
    public float Maxtime = 2f; // Max time interval between spawns
    private float _Maxtime;
    public float obstacle_speed = 2f;
    [Range(0,0.5f)]public float MaxTimeFactor = 0.2f ;
    [Range(0,0.5f)]public float obstacle_speedFactor = 0.2f;
    public float timeAlive = 1f;
    private void Start()
    {
        GameManager.Instance.onPlay.AddListener(ResetFactors);
    }
    void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            timeAlive += Time.deltaTime;
            if (Obstacle.Instance != null)
            {
                CalculateFactors();
            }
            SpawnLoop();
        }
    }

    public void SpawnLoop()
    {
        // Increment the timer
        currentTime += Time.deltaTime;


        // Check if it's time to spawn a new obstacle
        if (currentTime >= _Maxtime)
        {
            Spawn();
            // Reset the timer and set the next spawn interval
            currentTime = 0f;
        }

    }
    public void Spawn()
    {
        GameObject obstacle_spawn = obstaclePrefabs[Random.Range(0,obstaclePrefabs.Length)];
        GameObject spawned_obstacle = Instantiate(obstacle_spawn, transform.position, Quaternion.identity);

    }
    private void CalculateFactors()
    {
        _Maxtime = Maxtime / Mathf.Pow(timeAlive, MaxTimeFactor);
        if (Obstacle.Instance != null)
        {
            Obstacle.Instance.Speed = obstacle_speed * Mathf.Pow(timeAlive, obstacle_speedFactor);
        }
        else
        {
            Debug.LogError("Obstacle instance is null.");
        }
    
    }
    private void ResetFactors()
    {
        timeAlive = 1f;
        Obstacle.Instance.Speed = obstacle_speed;
        _Maxtime = Maxtime;
    }


}
