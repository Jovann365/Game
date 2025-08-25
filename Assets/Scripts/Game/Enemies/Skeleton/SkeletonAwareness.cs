using UnityEngine;

public class SkeletonAwareness : MonoBehaviour
{
    public bool Awareness { get; set; }
    public Vector2 DirectionToPlayer { get; set; }

    private Transform Player;

    private void Awake()
    {
        Player = FindObjectOfType<PlayerMovement>().transform;

    }

    private void Update()
    {
        Vector2 enemyToPlayerVector = Player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;
    }

}
