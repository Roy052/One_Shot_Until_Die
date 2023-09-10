using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public GameObject gun;
    private Rigidbody2D rb;

    bool seeRight = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 5f;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        rb.velocity = movement * moveSpeed;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = (mousePosition - transform.position).normalized;

        if((direction.x > 0 && seeRight == false) || (direction.x < 0 && seeRight == true))
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            seeRight = !seeRight;
        }

        if (direction.x < 0)
            gun.transform.right = new Vector2(-direction.x, direction.y);
        else
            gun.transform.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * 10f;
        }
    }
}