using UnityEngine;

public class Obstacle : MonoBehaviour
{
    #region Singleton

    public static Obstacle Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;

    }

    #endregion
    private Rigidbody2D obstacle;
    public float Speed = 2.5f;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the Rigidbody2D component to the asteroid variable
        obstacle = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = -Speed;

    }
    void FixedUpdate()
    {
        // Calculate new position
        Vector2 newPosition = obstacle.position + movement * Speed * Time.fixedDeltaTime;

        // Clamp the new position to stay within the boundaries
        //newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        //newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // Move the Rigidbody to the clamped position
        obstacle.MovePosition(newPosition);

    }
}