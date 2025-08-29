using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 6;
    public Rigidbody2D rb;
    private PlayerMovement playerMovement;
    private int Timer = 0;
    public int direction;

    void Start()
    {
        if (direction == 0)
        {
            rb.linearVelocity = Vector2.down * speed;
        }
        else if (direction == 1)
        {
            rb.linearVelocity = Vector2.left * speed;
        }
        else if (direction == 2)
        {
            rb.linearVelocity = Vector2.up * speed;
        }
        else if (direction == 3)
        {
            rb.linearVelocity = Vector2.right * speed;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.GetComponent<Skeleton>())
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Timer++;
        if (Timer > 80)
        {
            Destroy(gameObject);
        }
    }

}
