using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    private float currentTime; // To track the time since the last spawn
    public float Maxtime = 3.5f; // Max time interval between spawns
    private float _Maxtime;
    public float obstacle_speed = 2f;
    [Range(0,3.98f)]public float MaxTimeFactor = 3.98f ;
    public float obstacle_speedFactor = 0.8f;

    public float timeAlive = 1f;
    public float timeEvent = 5f;
    public bool isEvent = false;

    private void Start()
    {
        GameManager.Instance.onPlay.AddListener(ResetFactors);
        GameManager.Instance.onEvent.AddListener(ActivateEvent);

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

            manageEvent();

            SpawnLoop();

        }
    }

    public void SpawnLoop()
    {
        currentTime += Time.deltaTime;
        
        if (currentTime >= _Maxtime )
        {
            Spawn(isEvent);
            currentTime = 0f;
        }

    }
    public void Spawn(bool isEvent )
    {
        if (isEvent == true){
            GameObject obstacle_spawn = obstaclePrefabs[Random.Range(3,obstaclePrefabs.Length)];
            GameObject spawned_obstacle = Instantiate(obstacle_spawn, transform.position, Quaternion.identity);
        }else{
            GameObject obstacle_spawn = obstaclePrefabs[Random.Range(0,4)];
            GameObject spawned_obstacle = Instantiate(obstacle_spawn, transform.position, Quaternion.identity);
        }

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

    public void ActivateEvent()
    {
        isEvent = true;
    }
    public void manageEvent()
    {
        if (isEvent == true && timeAlive >= 15f && timeEvent > 0f){
            timeEvent -= Time.deltaTime;
            Debug.Log("Event is active");
        }else{
            Debug.Log("Event is unactive");
            isEvent = false;
            timeEvent = 5f;
        }
    }

}
