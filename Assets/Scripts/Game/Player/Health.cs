using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    private Animator _animator;
    private bool flag =false;
    private PlayerMovement playerMovement;
    [SerializeField] private AudioClip[] gameOver;
    [SerializeField] private AudioClip[] audioHurt;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        health = 4;
        _animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        Skeleton skeleton = collision.GetComponent<Skeleton>();
        if (collision.gameObject.name.StartsWith("Skeleton"))
        {
            health--;
            if (health <= 0 && flag==false)
            {
                flag = true;
                _animator.SetBool("IsDead", true);
                playerMovement.enabled = false;
                SoundFX.instance.PlayRandomSoundFXClip(gameOver, transform, 1f);
                Destroy(gameObject,1.5f);
            }
            SoundFX.instance.PlayRandomSoundFXClip(audioHurt, transform, 1f);
        }
    }
}
