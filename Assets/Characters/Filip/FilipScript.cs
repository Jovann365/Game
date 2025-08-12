using System.Runtime.CompilerServices;
using UnityEngine;

public class FilipScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public Animator animator;
    private float moveSpeed = 2f;
    private float moveHorizontal;
    private float moveVertical;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

// Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        if (moveHorizontal>0 || moveHorizontal < 0)
        {
            myRigidbody.AddForce(new Vector2(moveHorizontal * moveSpeed, 0),ForceMode2D.Impulse);
        }
    }
}       