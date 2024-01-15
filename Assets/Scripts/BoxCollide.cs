using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxCollide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with the specific item
        if (collision.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }

}
