using UnityEngine;

public class BulletController : MonoBehaviour
{
    public enum BulletType
    {
        Player = 0,
        Enemy = 1
    }

    public BulletType type;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(type.ToString()))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}