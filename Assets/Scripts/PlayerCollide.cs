using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollide : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with the specific item
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            LoadGameOver();
            GameManager.Instance.GameOver();
        }
    }

    void LoadGameOver()
    {
        // Load by scene name
        SceneManager.LoadScene("GameOver");

        // Or load by scene index
        // SceneManager.LoadScene(sceneBuildIndex);
    }
}
