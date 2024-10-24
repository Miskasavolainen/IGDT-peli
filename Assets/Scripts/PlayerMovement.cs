using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    private bool isMoving = false; // Track whether the player is moving

    private void Update()
    {
        // Handle movement input
        if (isMoving)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        // Move the player forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public IEnumerator MoveForDuration(float duration)
    {
        isMoving = true; // Start moving
        yield return new WaitForSeconds(duration); // Wait for the specified duration
        isMoving = false; // Stop moving
    }
}
