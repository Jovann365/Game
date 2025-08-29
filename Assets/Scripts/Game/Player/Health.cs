using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    private Animator _animator;
    private bool flag =false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        health = 4;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        Skeleton skeleton = collision.GetComponent<Skeleton>();
        if (collision.gameObject.name.StartsWith("Skeleton") && !skeleton.dead)
        {
            health--;
            if (health <= 0 && flag==false)
            {
                flag = true;
                _animator.SetBool("IsDead", true);
                Destroy(gameObject,1.5f);
            }
        }
    }
}
