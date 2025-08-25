using UnityEngine;

public class Skeleton : MonoBehaviour {
    [SerializeField]
    public float speed = 2f;
    private Rigidbody2D skeleton;
    private SkeletonAwareness skeletonAwareness;
    private Vector2 targetDirection;
    public Animator animator;

    private void Awake()
    {
        skeleton = GetComponent<Rigidbody2D>();
        skeletonAwareness = GetComponent<SkeletonAwareness>();

    }

    public void Update()
    {
        UpdateTargetDirection();
        skeleton.position += targetDirection *speed*Time.deltaTime;
        if ((skeleton.position[0]-1 < targetDirection[0] || skeleton.position[0] + 1 < targetDirection[0]) && (skeleton.position[0] - 1 < targetDirection[0] || skeleton.position[0] + 1 < targetDirection[0]))
        {
            animator.SetTrigger("SkeletonAttack");
        }
    }

    private void UpdateTargetDirection()
    {
        targetDirection = skeletonAwareness.DirectionToPlayer;
    }
    
}
