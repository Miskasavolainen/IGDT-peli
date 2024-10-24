using System.Collections;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    public float range = 100f; // Range of the gun
    public GameObject bulletImpactEffect; // Visual effect on bullet impact
    public AudioClip shootSound; // Sound to play on shooting
    private AudioSource audioSource; // Audio source to play sounds

    private bool isShooting = false; // To prevent shooting too quickly
    public float fireRate = 0.2f; // Time between shots

    void Awake()
    {
        // Ensure your GameObject has an AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if the player has pressed the left mouse button
        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        isShooting = true;

        // Play shooting sound
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound);
        }

        // Use the camera's forward direction for the shot
        Vector3 shootDirection = playerCamera.transform.forward;

        // Debug visualization
        Debug.DrawRay(playerCamera.transform.position, shootDirection * range, Color.red, 2f);

        RaycastHit hit;
        // Perform the raycast
        if (Physics.Raycast(playerCamera.transform.position, shootDirection, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name); // Log the name of the hit object

            // Instantiate bullet impact effect
            if (bulletImpactEffect != null)
            {
                Instantiate(bulletImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }

            // Example: Handle hitting an enemy
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(50f); // Example damage value
            }
        }

        // Call a coroutine to handle the shooting cooldown
        StartCoroutine(ShootingCooldown());
    }

    private IEnumerator ShootingCooldown()
    {
        yield return new WaitForSeconds(fireRate); // Wait for the defined fire rate
        isShooting = false; // Allow shooting again
    }
}


