using System;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float stopDistance = 3f;   
    public float attackDistance = 5f; 
    [SerializeField] private AudioClip attackSound;

    private Rigidbody2D skeletonBody;
    private Animator animator;

    private Transform[] players; 

    public void Awake()
    {
        skeletonBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        players = new Transform[playerObjects.Length];

        for (int i = 0; i < playerObjects.Length; i++)
        {
            players[i] = playerObjects[i].transform;
        }
    }

    private void Update()
    {
        if (players == null || players.Length == 0) return;
        
        Transform closestPlayer = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform p in players)
        {
            if (p == null) continue;
            float dist = Vector2.Distance(transform.position, p.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestPlayer = p;
            }
        }

        if (closestPlayer == null) return;
        
        if (closestDistance > stopDistance)
        {
            animator.SetBool("Attack", false);
            transform.position = Vector2.MoveTowards(
                transform.position,
                closestPlayer.position,
                movementSpeed * Time.deltaTime
            );
        }
        else if (closestDistance <= attackDistance)
        {
            animator.SetBool("Attack", true);
            SoundFX.instance.PlaySoundFXClip(attackSound, transform, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent("Bullet"))
        {
            FindAnyObjectByType<ScoreManager>().increaseScore();
            animator.SetBool("IsDead", true);
            Destroy(gameObject, 0.1f);
        }
    }
}
