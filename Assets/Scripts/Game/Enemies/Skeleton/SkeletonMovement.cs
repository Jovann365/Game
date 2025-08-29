using System.Runtime.CompilerServices;
using UnityEngine;

public class Skeleton : MonoBehaviour {
    [SerializeField]
    public float speed = 2f;
    private Rigidbody2D skeleton;
    private SkeletonAwareness skeletonAwareness;
    private Vector2 targetDirection;
    private Animator animator;
    private Collider2D collision;
    public int lives = 2;
    public bool dead = false;
    public Transform player;
    public float attackRange = 10f;
    public bool inRange = false;
    public float RetrieveDistance = 2f;

    private void Awake()
    {
        skeleton = GetComponent<Rigidbody2D>();
        skeletonAwareness = GetComponent<SkeletonAwareness>();
        animator = GetComponent<Animator>();
        collision = GetComponent<Collider2D>();
    }

    public void Update()
    {
        if (!dead)
        {
            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                inRange = true;

            }
            else
            {
                inRange = false;
            }
            if (inRange)
            {



            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsNearPlayer", true);
        }
        else
        {
            animator.SetBool("IsNearPlayer", false);
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
        }
    }

    private void UpdateTargetDirection()
    {
        targetDirection = skeletonAwareness.DirectionToPlayer;
    }
    private void TakeDamage()
    {
        lives--;
        animator.SetBool("Hurt",true);
        if (lives == 0)
        {
            dead = true;
            animator.SetBool("IsDead",true);

            Destroy(gameObject,1f);
        }
    }
   
}
