using UnityEngine;
using UnityEngine.SceneManagement;
public class KillPlayer : MonoBehaviour
{
    [SerializeField] int respawn; // The number of the scene that should load

    /// <summary>
    /// This script looks for whether the enemy collides with the player and reloads the first scene
    /// </summary>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(respawn);
        }
    }
}
