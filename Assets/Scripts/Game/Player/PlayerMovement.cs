using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Sprite[] rotationSprites;
    private SpriteRenderer _spriteRenderer;
    
    private Rigidbody2D _rigidbody;
    private Vector2 _moveInput; 
    private int _lastDirectionIndex = 0;
    private Animator _animator;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (_moveInput != Vector2.zero)
        { 
            if (Mathf.Abs(_moveInput.x) > Mathf.Abs(_moveInput.y))
            {
                _lastDirectionIndex = _moveInput.x > 0 ? 3 : 1; 
            }
            else
            {
                _lastDirectionIndex = _moveInput.y > 0 ? 2 : 0; 
            }
        }
        
        if (rotationSprites != null && rotationSprites.Length >= 4)
        {
            _spriteRenderer.sprite = rotationSprites[_lastDirectionIndex];
        }
        
        SetAnimation();
        
        _rigidbody.linearVelocity = _moveInput * 3f;
    }

    private void OnMove(InputValue inputValue)
    {
        _moveInput = inputValue.Get<Vector2>();   
    }

    private void SetAnimation()
    {
        bool isMoving = _moveInput != Vector2.zero;
        
        _animator.SetBool("movingDown", false);
        _animator.SetBool("movingLeft", false);
        _animator.SetBool("movingUp", false);
        _animator.SetBool("movingRight", false);
        
        if (isMoving)
        {
            if (_lastDirectionIndex == 0) _animator.SetBool("movingDown", true);
            else if (_lastDirectionIndex == 1) _animator.SetBool("movingLeft", true);
            else if (_lastDirectionIndex == 2) _animator.SetBool("movingUp", true);
            else if (_lastDirectionIndex == 3) _animator.SetBool("movingRight", true);
        }
    }
}
