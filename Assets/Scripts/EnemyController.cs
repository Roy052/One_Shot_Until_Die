using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float shootInterval = 1;
    public float bulletSpreadAngle = 180f;
    public int bulletCount = 1;
    public int bulletMinCount = 1, bulletMaxCount = 1;
    public bool isMove, isShootMany;

    private float shootTimer;

    private void Start()
    {
        shootTimer = Random.Range(0.05f, shootInterval);
    }

    private void Update()
    {
        // Update the shoot timer
        shootTimer -= Time.deltaTime;

        // Shoot bullets if the shoot timer reaches 0
        if (shootTimer <= 0f)
        {
            Shoot();
            shootTimer = Random.Range(0, shootInterval);
        }
    }

    private void Shoot()
    {
        // Calculate the number of bullets to shoot
        int bulletCount = 1;
        if (isShootMany)
             bulletCount = Random.Range(bulletMinCount, bulletMaxCount);

        // Calculate the angle increment for each bullet
        float angleIncrement = bulletSpreadAngle / bulletCount;

        // Calculate the starting angle for the first bullet
        float startAngle = Random.Range(0f, 360f);

        // Iterate through the bullet count and instantiate bullets
        for (int i = 0; i < bulletCount; i++)
        {
            // Calculate the angle for the current bullet
            float angle = startAngle + (i * angleIncrement);

            // Calculate the rotation based on the angle
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

            // Instantiate the bullet with the rotation
            GameObject bullet = Instantiate(bulletPrefab, transform.position, rotation);

            // Calculate the bullet direction based on the rotation
            Vector2 bulletDirection = bullet.transform.right;

            // Apply velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;
        }
    }
}
