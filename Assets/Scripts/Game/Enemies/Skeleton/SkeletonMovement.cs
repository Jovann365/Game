using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public float movementSpeed = 2f;
    public Transform player;
    public float stopDistance = 3f;  // how close to get to the player
    public float attackDistance = 5f;  // when to start attacking
    [SerializeField] private AudioClip attackSound;
    public Rigidbody2D skeletonBody;

    public Animator animator;

    public void Awake()
    {
        skeletonBody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
    }


    private void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance > stopDistance)
        {
            animator.SetBool("Attack",false);
            transform.position = Vector2.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
        }
        else if (distance <= attackDistance)
        {
            animator.SetBool("Attack", true);
            SoundFX.instance.PlaySoundFXClip(attackSound, transform, 1f);
            Destroy(SoundFX.instance.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent("Bullet"))
        {
            FindAnyObjectByType<ScoreManager>().increaseScore();
            animator.SetBool("IsDead", true);
            Destroy(gameObject, 0.1f);
        }
    }
}
