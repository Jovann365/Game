using UnityEngine;

public class Health : MonoBehaviour
{
    private int health;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGER HEALTH");
        
        if (collision.gameObject.name.StartsWith("Skeleton"))
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
