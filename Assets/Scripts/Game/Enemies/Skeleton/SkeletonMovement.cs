using System.Runtime.CompilerServices;
using UnityEngine;

public class Skeleton : MonoBehaviour {
    [SerializeField]
    public float speed = 2f;
    private Rigidbody2D skeleton;
    private SkeletonAwareness skeletonAwareness;
    [SerializeField] private AudioClip skeletonHurt;
    private Vector2 targetDirection;
    private Animator animator;
    private Collider2D collision;
    public int lives = 2;
    public bool dead = false;

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
            UpdateTargetDirection();
            skeleton.position += targetDirection * speed * Time.deltaTime;
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
        SoundFX.instance.PlaySoundFXClip(skeletonHurt, transform, 1f);
        animator.SetBool("Hurt",true);
        if (lives == 0)
        {
            dead = true;
            animator.SetBool("IsDead",true);

            Destroy(gameObject,1f);
        }
    }
   
}
